using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    ScoreManager instance;
    public int releaseScore;
    public int meditateScore;
    public int balletScore;
    public Text ScoreUI;

    void Awake() {
        GetInstance();
    }

    ScoreManager GetInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update() {
        ShowScore();
    }

    void ShowScore() {
        ScoreUI.text = "Release: " + releaseScore + "/3" + "/n"+
            "Meditate: " + meditateScore + "/1" + "/n"+
            "Ballet: " + balletScore + "/2" + "/n";
    }
}
