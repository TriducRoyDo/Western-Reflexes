using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int lives;
    public int bullets;
    public AudioSource gunshot;
    public AudioSource reload;
    public AudioSource emptygun;
    public AudioSource evilLaugh;
    public AudioSource powerUpGetSound;
    public AudioSource fastReloadReady;
    public GameObject infiniteIcon;
    public GameObject speedUpIcon;
    public GameObject slowDownIcon;
    public GameObject doublePointsIcon;
    public Image damagedScreen;
    public Text fastReloadText;
    float infinitePowerupTimer;
    float speedUpTimer;
    float speedDownTimer;
    float fastReloadTimer;
    float doublePointsTimer;


    // stuff used to determine if the phone is shook
    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    float shakeDetectionThreshold = 1f;
    float lowPassFilterFactor;
    Vector3 lowPassValue;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        bullets = 6;
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
        infinitePowerupTimer = -100;
        speedDownTimer = -100;
        speedUpTimer = -100;
        doublePointsTimer = -100;
        fastReloadTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        Vector3 deltaAcceleration = acceleration - lowPassValue;

        if ((deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold) && (fastReloadTimer <= 0)) {
            // Perform your "shaking actions" here. If necessary, add suitable
            // guards in the if check above to avoid redundant handling during
            // the same shake (e.g. a minimum refractory period).
            Debug.Log("Shake event detected at time " + Time.time);
            setBullets(6);
            fastReloadTimer = 3;
        }


        // fast reload with the F key for debugging purposes.
        if (Input.GetKeyDown("f") && (fastReloadTimer <= 0)) {
            setBullets(6);
            fastReloadTimer = 3;
        }


        applyPowerups();
        updateFastReloadLabel();
    }

    private void updateFastReloadLabel() {
        if(fastReloadTimer <= 0) {
            fastReloadText.text = "Fast \nReload \nReady!";
        } else {
            fastReloadTimer -= Time.unscaledDeltaTime;
            fastReloadText.text = "Cool \nDown\n"+ fastReloadTimer.ToString();
            // if the fast Reload cooldown ends, play this soundeffect
            if(fastReloadTimer <= 0) {
                fastReloadReady.Play();
            }
        }
    }

    public int getLives() {
        return lives;
    }

    public void setLives(int lives) {
        this.lives = lives;
    }

    public int getBullets() {
        return bullets;
    }
    
    public void setBullets(int bullets) {
        this.bullets = bullets;
        reload.Play();
        Debug.Log("Bullets reloaded to " + bullets);
    }

    public void reloadOneBullet() {
        if (bullets < 6) {
            setBullets((bullets + 1));
        }
        else {
            Debug.Log("Gun already has " + bullets + " bullets. Can't reload.");
        }
    }

    bool hasBullets() {
        if(bullets > 0) {
            return true;
        }
        else {
            return false;
        }
    }

    //if we have bullets, fire one. Otherwise return false
    public bool shootGun() {
        if (hasBullets()) {
            gunshot.Play();
            bullets -= 1;
            return true;
        }
        else {
            emptygun.Play();
            Debug.Log("no bullets to shoot!");
            return false;
        }
    }

    public void playerHurt() {
        lives--;
        evilLaugh.Play();
        bool getDamage = true;

        // screen gets more red through the use of a hidden UIPanel that gets more opaque
        if (getDamage) {
            Color Opaque = new Color(1, 1, 1, 1);
            damagedScreen.color = Color.Lerp(damagedScreen.color, Opaque, 20 * Time.deltaTime);
            if (damagedScreen.color.a <= 0.8) //Almost Opaque, close enough
            {
                getDamage = false;
            }
        }
        if (!getDamage) {
            Color Transparent = new Color(1, 1, 1, 0);
            damagedScreen.color = Color.Lerp(damagedScreen.color, Transparent, 20 * Time.deltaTime);
        }

        if (lives <= 0) {
            damagedScreen.gameObject.SetActive(false);
            FindObjectOfType<GameController>().gameOver();
        }
    }

    // called from PowerupsController. When a powerup is obtained, it's duration is recorded here. Grabbing a powerup while its active simply
    // resets its active duration to maximum.
    public void gotPowerUp(string powerUp) {
        if (powerUp.Equals("infinite")) {
            infinitePowerupTimer = 7;
            fastReloadTimer = 0;
            infiniteIcon.SetActive(true);
            Debug.Log("obtained infinite. Remaining time: " + infinitePowerupTimer);
        } 

        // when the speedDown powerup is obtained, if speedUp is active, remove its effects then apply speedDown. Repeated uses stack the slow down effect.
        else if (powerUp.Equals("speedDown")) {
            if (speedUpTimer > 0) {
                speedUpIcon.SetActive(false);
                speedUpTimer = -100;
                FindObjectOfType<GameController>().alterGamespeed("reset");
                Debug.Log("speedUp ended");
            }
            slowDownIcon.SetActive(true);
            speedDownTimer = 5;
            FindObjectOfType<GameController>().alterGamespeed("slower");
            Debug.Log("obtained speedDown. Remaining time: " + speedDownTimer);
        }

        // same as speedDown but opposite effects.
        else if (powerUp.Equals("speedUp")) {
            if (speedDownTimer > 0) {
                slowDownIcon.SetActive(false);
                speedDownTimer = -100;
                FindObjectOfType<GameController>().alterGamespeed("reset");
                Debug.Log("speedDown ended");
            }
            speedUpIcon.SetActive(true);
            speedUpTimer = 7;
            FindObjectOfType<GameController>().alterGamespeed("faster");
            Debug.Log("obtained speedUp. Remaining time: " + speedUpTimer);
        }

        else if (powerUp.Equals("lifeUp")) {
            lives++;
            Debug.Log("Life up powerup. Lives: " + lives);
        }

        else if (powerUp.Equals("double")) {
            FindObjectOfType<GameController>().setDoublePointsMultipler(true);
            doublePointsTimer = 7;
            doublePointsIcon.SetActive(true);
            Debug.Log("obtained double points. Remaining Time: " + doublePointsTimer);
        }

    }

    //Keeps track of powerups duration while they are active and may apply their effects. Note 0 on the timer indicates the time
    //when a powerup ends while -100 indicates that the player does not currently have the powerup active.
    void applyPowerups() {

        // keep bullets fully reloaded while this powerup is active.
        if(infinitePowerupTimer > 0) {
            bullets = 6;
            fastReloadTimer = 0;
            // unscaledDeltaTime is unaffected by changes to timescale so powersup will last the same amount 
            // even if the time is spedup or slowed down by other powerups.
            infinitePowerupTimer -= Time.unscaledDeltaTime;
        }
        if(speedDownTimer > 0) {
            speedDownTimer -= Time.unscaledDeltaTime;
        }
        if (speedUpTimer > 0) {
            speedUpTimer -= Time.unscaledDeltaTime;
        }
        if (doublePointsTimer > 0) {
            doublePointsTimer -= Time.unscaledDeltaTime;
        }

        // when a powerup durations ends, set it to the inactive value of -100. 
        // When set at the inactive value, we don't have to continously do these functions
        if ((infinitePowerupTimer < 0) && (infinitePowerupTimer > -100)) {
            infiniteIcon.SetActive(false);
            infinitePowerupTimer = -100;
            Debug.Log("infinite bullets ended");
        }

        // when speedUp or speedDown ends, reset the timescale to 1.0, 
        if ((speedDownTimer <= 0) && (speedDownTimer > -100)) {
            slowDownIcon.SetActive(false);
            speedDownTimer = -100;
            FindObjectOfType<GameController>().alterGamespeed("reset");
            Debug.Log("speedDown ended");

        }
        if ((speedUpTimer <= 0) && (speedUpTimer > -100)) {
            speedUpIcon.SetActive(false);
            speedUpTimer = -100;
            FindObjectOfType<GameController>().alterGamespeed("reset");
            Debug.Log("speedUp ended");

        }
        if ((doublePointsTimer <= 0) && (doublePointsTimer > -100)) {
            doublePointsIcon.SetActive(false);
            doublePointsTimer = -100;
            FindObjectOfType<GameController>().setDoublePointsMultipler(false);
            Debug.Log("speedUp ended");

        }
    }

    public void playPowerUpGet() {
        powerUpGetSound.Play();
    }
}
