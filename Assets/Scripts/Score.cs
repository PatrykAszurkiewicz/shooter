using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public static int scoreValue = 0;
    Text score;

    public Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        scoreValue = 0;
        score = GetComponent<Text>();
    }
    void Update()
    {
        
        score.text = "Score: " + scoreValue.ToString();

        PlayerPrefs.SetInt("HighScore", scoreValue);
    }

}
