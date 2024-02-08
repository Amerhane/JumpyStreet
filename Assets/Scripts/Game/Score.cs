using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int score;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        //Check when player jumps and increment score.

        //Check if player is dead.
        //If dead, compare high scores.
        //Create prompt to enter name if high score.
    }

    private void SaveScore(int score, string playerName)
    {
        PlayerPrefs.SetInt("highScore", score);
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();
    }

    private int LoadScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    private string LoadPlayerName()
    {
        return PlayerPrefs.GetString("playerName", "Player");
    }
}
