using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script is intended to close the tutorial when anywhere on the bg (black box) is touched.
public class TutorialClosed : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject babyPic;
    public GameObject armorPic;
    public GameObject movingPic;
    public GameObject movingArmorPic;
    public GameObject unknownPic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {
        Debug.Log("Tutorial closed.");
        Time.timeScale = 1.0f;
        Tutorial.gameObject.SetActive(false);
        babyPic.gameObject.SetActive(false);
        armorPic.gameObject.SetActive(false);
        movingPic.gameObject.SetActive(false);
        movingArmorPic.gameObject.SetActive(false);
        unknownPic.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
