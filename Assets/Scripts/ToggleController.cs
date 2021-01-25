using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public Toggle TutorialToggle;
    bool isOn;
    // Start is called before the first frame update
    void Start(){
        // set the Tutorial toggle to what it was in the previous session which is stored in playerprefs. 
        if(PlayerPrefs.GetInt("TutorialToggle") == 1) {
            isOn = true;
        }
        else {
            isOn = false;
        }
        TutorialToggle.SetIsOnWithoutNotify(isOn);
    }

    // Update is called once per frame
    void Update(){
        
    }

    // controls when the toggle is clicked
    public void setTutorial() {
        if (TutorialToggle.isOn) {
            PlayerPrefs.SetInt("TutorialToggle", 1);
        }
        else {
            PlayerPrefs.SetInt("TutorialToggle", 0);
        }
        Debug.Log("Tutorial toggle is set to " + PlayerPrefs.GetInt("TutorialToggle"));
    }
}
