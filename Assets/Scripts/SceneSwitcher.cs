using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void switchToHighscoreScreen() {
        SceneManager.LoadScene("HighScores", LoadSceneMode.Single);
    }

    public void switchToPlayGameScreen() {
        SceneManager.LoadScene("PlayGame", LoadSceneMode.Single);
    }

    public void switchToMainMenuScreen() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}
