using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text ScoreLabel;
    public Text LivesLabel;
    public Text BulletsLabel;
    public Text HighscoreLabel;
    public Text GameOverText;
    public Text HighscoreText;
    public GameObject GameOverButtons;
    public GameObject HighscoreUI;
    public GameObject npc1;
    public GameObject[] wave2;
    public GameObject[] wave3;
    public GameObject[] wave4;
    public GameObject[] waveFinalA;
    public GameObject[] waveFinalB;
    public GameObject[] powerupsSelection;
    public InputField HighscoreInputField;
    public int score;
    public int bullets;
    public int lives;
    bool gotHS1 = false;
    bool gotHS2 = false;
    bool gotHS3 = false;
    bool doublePointsMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1.0f;
        StartCoroutine(spawnNPCs());
        if (PlayerPrefs.HasKey("highscore")) {
            HighscoreLabel.text = "Highscore: "+ PlayerPrefs.GetInt("highscore");
        }
        score = 0;
        doublePointsMultiplier = false;
        updateLabels();
    }

    // Update is called once per frame
    void Update() {
        updateLabels();

        // brings up new tutorials when appropriate
        if (PlayerPrefs.GetInt("TutorialToggle") == 1) {
            FindObjectOfType<TutorialController>().newMechanicsTutorial();
        }

        // small chance to spawn powerups
        if(Random.Range(0,1000) < 1) {
            spawnPowerups();
        }
    }

    // spawn NPCs from a certain array and at certain intervals based on score.
    IEnumerator spawnNPCs() {
        while (true) {
            if (score < 200) {
                // chance that 2 npcs will spawn at once.
                if (Random.Range(0, 2) < 1) {
                    Instantiate(npc1);
                    Instantiate(npc1);
                    Debug.Log("double npc spawned");
                }
                else {
                    Instantiate(npc1);
                    Debug.Log("npc spawned");
                }

                // spawns enemy at an irregular pace
                float spawnEnemy = Random.Range(1.5f, 3);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 400) {
                if (Random.Range(0, 3) < 1) {
                    Instantiate(wave2[Random.Range(0, 3)]);
                    Instantiate(wave2[Random.Range(0, 3)]);
                    Debug.Log("double npc spawned");
                }
                else {
                    Instantiate(wave2[Random.Range(0, 3)]);
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(1.3f, 2.5f);
                yield return new WaitForSeconds(spawnEnemy);

            }
            else if (score < 800) {
                if (Random.Range(0, 3) < 1) {
                    Instantiate(wave3[Random.Range(0, 5)]);
                    Instantiate(wave3[Random.Range(0, 5)]);
                    Debug.Log("double npc spawned");
                }
                else {
                    Instantiate(wave3[Random.Range(0, 5)]);
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(1.2f, 2.2f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 1200) {
                if (Random.Range(0, 3) < 1) {
                    Instantiate(wave4[Random.Range(0, 6)]);
                    Instantiate(wave4[Random.Range(0, 6)]);
                    Debug.Log("double npc spawned");
                }
                else {
                    Instantiate(wave4[Random.Range(0, 6)]);
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.95f, 2.1f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 1900) {
                if (Random.Range(0, 3) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.9f, 1.85f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 2500) {
                if (Random.Range(0, 3) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();

                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.85f, 1.75f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 3500) {
                if (Random.Range(0, 4) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.7f, 1.75f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 5000) {
                if (Random.Range(0, 3) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.65f, 1.8f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 7000) {
                if (Random.Range(0, 2) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.65f, 1.8f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 9000) {
                if (Random.Range(0, 2) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.6f, 1.7f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 12500) {
                if (Random.Range(0, 2) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.5f, 1.65f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 16000) {
                if (Random.Range(0, 2) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.5f, 1.5f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score < 20000) {
                if (Random.Range(0, 2) < 1) {
                    spawnEnemyWaveFinal();
                    spawnEnemyWaveFinal();
                    Debug.Log("double npc spawned");
                }
                else {
                    spawnEnemyWaveFinal();
                    Debug.Log("npc spawned");
                }
                float spawnEnemy = Random.Range(0.5f, 1.45f);
                yield return new WaitForSeconds(spawnEnemy);
            }

            //at this point always spawn npcs at a time
            else if (score < 27000) {
                spawnEnemyWaveFinal();
                spawnEnemyWaveFinal();
                Debug.Log("double npc spawned");
               
                float spawnEnemy = Random.Range(0.5f, 1.85f);
                yield return new WaitForSeconds(spawnEnemy);
            }
            else if (score >= 27000) {
                spawnEnemyWaveFinal();
                spawnEnemyWaveFinal();
                float spawnEnemy = Random.Range(0.5f, 1.5f);
                yield return new WaitForSeconds(spawnEnemy);
            }
        }
    }

    //updates the score, lives, and bullet UI.
    void updateLabels() {
        lives = FindObjectOfType<PlayerController>().getLives();
        bullets = FindObjectOfType<PlayerController>().getBullets();
        ScoreLabel.text = "Score: " + score;
        LivesLabel.text = "Lives: " + lives;
        BulletsLabel.text = "Bullets: " + bullets;
    }

    public void updateScore(int value) {
        // don't increase score if game has ended.
        if (Time.timeScale != 0) {
            if (doublePointsMultiplier) {
                score += (value * 2);
            }
            else {
                score += value;
            }
            updateLabels();
        }
    }

    public void gameOver() {
        Time.timeScale = 0.0f;
        Debug.Log("Game over");
        GameOverText.gameObject.SetActive(true);
        if (!checkForHighscore()) {
            GameOverButtons.SetActive(true);
        }
        
    }

    public void restartGame() {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    // checks to see if the user's score has beaten any of the top 3 scores. If they did, it reveals the highscoreUI
    // and checks to see which ranking the user got specifically.
    public bool checkForHighscore() {
        int highscore1 = PlayerPrefs.GetInt("highscore");
        int highscore2 = PlayerPrefs.GetInt("highscore2");
        int highscore3 = PlayerPrefs.GetInt("highscore3");
        if (highscore3 < score) {
            HighscoreUI.SetActive(true);
            if(score > highscore1) {
                Debug.Log("highscore #1 achieved.");
                HighscoreText.text = "Congratulations! Highscore #1 acheived! Please enter your name: ";
                gotHS1 = true;
            }
            else if(score > highscore2){
                Debug.Log("highscore #2 achieved. " + highscore2);
                HighscoreText.text = "Congratulations! Highscore #2 acheived! Please enter your name: ";
                gotHS2 = true;
            }
            else {
                Debug.Log("highscore #3 achieved.");
                HighscoreText.text = "Congratulations! Highscore #3 acheived! Please enter your name: ";
                gotHS3 = true;
            }
            return true;
        }
        else {
            return false;
        }
    }

    // using the gotHS bools, we know which highscore the user has gotten. This function then submits
    // the user's inputted name and score into the appropriate database.
    public void submitHighscore() {
        string name = HighscoreInputField.text;

        // if the user got the #1 or #2 highest score, we have to move the scores below it one rank down each.
        if (gotHS1) {
            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2"));
            PlayerPrefs.SetString("highscore3Name", PlayerPrefs.GetString("highscore2Name"));
            PlayerPrefs.SetInt("highscore2", PlayerPrefs.GetInt("highscore"));
            PlayerPrefs.SetString("highscore2Name", PlayerPrefs.GetString("highscoreName"));
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.SetString("highscoreName", name);
            // since the user got the #1 highscore, we also instantly update the highscore label
            HighscoreLabel.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
            gotHS1 = false;
        } 
        else if (gotHS2) {
            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2"));
            PlayerPrefs.SetString("highscore3Name", PlayerPrefs.GetString("highscore2Name"));
            PlayerPrefs.SetInt("highscore2", score);
            PlayerPrefs.SetString("highscore2Name", name);
            gotHS2 = false;
        }
        else if (gotHS3) {
            PlayerPrefs.SetInt("highscore3", score);
            PlayerPrefs.SetString("highscore3Name", name);
            gotHS3 = false;
        }

        // finally, hide the highscoreUI and show the normal GameOver buttons.
        HighscoreUI.SetActive(false);
        GameOverButtons.SetActive(true);
    }

    public int getScore() {
        return score;
    }

    // changes how fast or slow the game will operate.
    public void alterGamespeed(string speedChange) {
        if (speedChange.Equals("faster")) {
            Time.timeScale *= 1.5f;
            Debug.Log("timescale increased to " + Time.timeScale);
        } 
        else if (speedChange.Equals("slower")) {
            Time.timeScale *= 0.5f;
            Debug.Log("timescale lowered to " + Time.timeScale);
        } 
        else if (speedChange.Equals("reset")){
            Time.timeScale = 1;
            Debug.Log("timescale altered to " + Time.timeScale);
        }
        
    }

    // spawn a random powerup.
    void spawnPowerups() {
        if (Time.timeScale != 0) {
            Instantiate(powerupsSelection[Random.Range(0, 5)]);
        }
    }

    public void setDoublePointsMultipler(bool b) {
        doublePointsMultiplier = b;
    }

    // for balance purposes. When the game spawning speed gets really fast, armor enemies are less likely to appear.
    public void spawnEnemyWaveFinal() {
        if(Random.Range(0,3) < 1) {
            Instantiate(waveFinalB[Random.Range(0, 2)]);
        }
        else {
            Instantiate(waveFinalA[Random.Range(0, 4)]);
        }
    }

}
