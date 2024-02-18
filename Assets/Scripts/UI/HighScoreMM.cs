using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreMM : MonoBehaviour
{
    [SerializeField]
    private TMP_Text highScoreText;

    private int highScore;
    private string playerName;

    public void Start()
    {
        highScoreText.text = GetHighScoreText();
    }

    private string GetHighScoreText()
    {
        return "High Score: " + LoadScore().ToString() + 
            "\nSet By: " + LoadPlayerName();
    }

    private int LoadScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    private string LoadPlayerName()
    {
        return PlayerPrefs.GetString("playerName", "None");
    }
}
