using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
    public Text Highscore1NameLabel;
    public Text Highscore2NameLabel;
    public Text Highscore3NameLabel;
    public Text Highscore1ScoreLabel;
    public Text Highscore2ScoreLabel;
    public Text Highscore3ScoreLabel;



    // Start is called before the first frame update
    void Start()
    {
        updateHighscores();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clearHighscores() {
        PlayerPrefs.SetInt("highscore", 0);
        PlayerPrefs.DeleteKey("highscoreName");
        PlayerPrefs.SetInt("highscore2", 0);
        PlayerPrefs.DeleteKey("highscore2Name");
        PlayerPrefs.SetInt("highscore3", 0);
        PlayerPrefs.DeleteKey("highscore3Name");
        updateHighscores();
        Debug.Log("Highscores cleared.");


    }

    void updateHighscores() {
        if (PlayerPrefs.HasKey("highscore")) {
            Highscore1NameLabel.text = PlayerPrefs.GetString("highscoreName");
            Highscore1ScoreLabel.text = "$" + PlayerPrefs.GetInt("highscore").ToString();
        }
        if (PlayerPrefs.HasKey("highscore2")) {
            Highscore2NameLabel.text = PlayerPrefs.GetString("highscore2Name");
            Highscore2ScoreLabel.text = "$" + PlayerPrefs.GetInt("highscore2").ToString();

        }
        if (PlayerPrefs.HasKey("highscore3")) {
            Highscore3NameLabel.text = PlayerPrefs.GetString("highscore3Name");
            Highscore3ScoreLabel.text = "$" + PlayerPrefs.GetInt("highscore3").ToString();

        }
    }
}
