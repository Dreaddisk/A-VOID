using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour {

    public static int scoreValue = 0;
     Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score.text = "Score: " + scoreValue;

        if (scoreValue >= 100) {

            score.text = "You have become the Admiral";
            Time.timeScale = 0;
        }
    }
} // Main class
