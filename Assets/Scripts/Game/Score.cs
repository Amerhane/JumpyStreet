using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Project: JumpyStreet
/// Name: Jacob Frigon
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField]
    private int score;
    [SerializeField]
    private TMP_Text scoreText;

    private GameObject player;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        int nextScore = Mathf.RoundToInt(player.transform.position.x);
        if (nextScore > score)
        {
            score = nextScore;
            scoreText.text = score.ToString();
        }
    }

    public int GetPlayerScore()
    {
        return score;
    }

    public void SaveScore(int score, string playerName)
    {
        PlayerPrefs.SetInt("highScore", score);
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();
    }

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }

    public string LoadPlayerName()
    {
        return PlayerPrefs.GetString("playerName", "Player");
    }
}
