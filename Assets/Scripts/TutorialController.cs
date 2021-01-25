using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this controls when the tutorial appears and what it'll show. Note that the tutorial pauses the game by freezing the timescale.
// the timescale is only resumed when tutorialClosed is prompted.
public class TutorialController : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject babyPic;
    public GameObject armorPic;
    public GameObject movingPic;
    public GameObject movingArmorPic;
    public GameObject unknownPic;
    public GameObject blackbg;
    public Text TutorialText;
    bool seenTut2;
    bool seenTut3;
    bool seenTut4;
   
    // Start is called before the first frame update
    void Start()
    {
        babyPic.gameObject.SetActive(false);
        armorPic.gameObject.SetActive(false);
        movingPic.gameObject.SetActive(false);
        movingArmorPic.gameObject.SetActive(false);
        unknownPic.gameObject.SetActive(false);

        // bring up the tutorial when the scene starts if tutorial is enabled. Also pause time so game doesn't start. Otherwise, start like normally.
        if (PlayerPrefs.GetInt("TutorialToggle") == 1) {
            Time.timeScale = 0.0f;
            Tutorial.gameObject.SetActive(true);
            blackbg.gameObject.SetActive(true);
            seenTut2 = false;
            seenTut3 = false;
            seenTut4 = false;
        }
        else {
            Time.timeScale = 1.0f;
            blackbg.gameObject.SetActive(false);
            Tutorial.gameObject.SetActive(false);        
        }
    }

    // Update is called once per frame
    void Update() {
    }


    // brings up the tutorial again when new enemies are introduced to the game.
    public void newMechanicsTutorial() {
     if((FindObjectOfType<GameController>().getScore() >= 200) && (seenTut2 == false)) {
            seenTut2 = true;
            Time.timeScale = 0.0f;
            TutorialText.text = "New types of travelers inbound. Watch out for babies, shoot them and you'll lose 2 lives, just let them crawl by. Silver" +
                " outlaws packing bullet vests have been spotted. They're worth more points but also require two bullets to down.";
            Tutorial.gameObject.SetActive(true);
            blackbg.gameObject.SetActive(true);
            babyPic.gameObject.SetActive(true);
            armorPic.gameObject.SetActive(true);
            Debug.Log("tutorial 2 started");
        }
     else if ((FindObjectOfType<GameController>().getScore() >= 400) && (seenTut3 == false)) {
            seenTut3 = true;
            Time.timeScale = 0.0f;
            TutorialText.text = "New types of travelers inbound. These are variants of the previous baddies except these nimble varmints will" +
                " move around to avoid getting shot! The harder the kill, the more points you'll get.";
            Tutorial.gameObject.SetActive(true);
            blackbg.gameObject.SetActive(true);
            movingPic.gameObject.SetActive(true);
            movingArmorPic.gameObject.SetActive(true);
            Debug.Log("tutorial 3 started");
        }
        else if ((FindObjectOfType<GameController>().getScore() >= 800) && (seenTut4 == false)) {
            seenTut4 = true;
            Time.timeScale = 0.0f;
            TutorialText.text = "Unknown faces in town. This walking man could be a civilian or a quick-draw assassin. Keep an eye" +
                " on him but don't fire unless he draws a weapon!";
            unknownPic.SetActive(true);
            blackbg.gameObject.SetActive(true);
            Tutorial.gameObject.SetActive(true);
            
        }
    }
}
