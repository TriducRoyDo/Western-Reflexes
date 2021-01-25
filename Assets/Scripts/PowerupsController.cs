using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsController : MonoBehaviour
{
    float timeElapsed;


    public enum powerupType {
        infiniteBullets,
        speedUp,
        speedDown,
        lifeUp,
        doublePoints
    }

    public powerupType type;
    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        destroyPowerupsOverTime();
        if (Time.timeScale == 0) {
            Destroy(gameObject);
        }
    }

    void OnMouseDown() {
        if (FindObjectOfType<PlayerController>().shootGun()) {
            if (type == powerupType.infiniteBullets) {
                FindObjectOfType<PlayerController>().gotPowerUp("infinite");
            }
            else if (type == powerupType.speedDown) {
                FindObjectOfType<PlayerController>().gotPowerUp("speedDown");
            }
            else if (type == powerupType.speedUp) {
                FindObjectOfType<PlayerController>().gotPowerUp("speedUp");
            }
            else if (type == powerupType.lifeUp) {
                FindObjectOfType<PlayerController>().gotPowerUp("lifeUp");

            }
            else if (type == powerupType.doublePoints) {
                FindObjectOfType<PlayerController>().gotPowerUp("double");

            }

            FindObjectOfType<PlayerController>().playPowerUpGet();
            Destroy(gameObject);
        }
    }

    // after 3 seconds, if the powerup is unclaimed then it disappears.
    void destroyPowerupsOverTime() {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 3) {
            Destroy(gameObject);
        }
    }
}
