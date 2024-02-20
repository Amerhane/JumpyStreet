using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuObject;
    [SerializeField]
    private GameObject gameOverMenu;

    [SerializeField]
    private Score scoreSystem;

    [SerializeField]
    private TMP_Text highScoreNumText;
    [SerializeField]
    private TMP_Text yourScoreNumText;

    [SerializeField]
    private GameObject highScoreMenu;
    [SerializeField]
    private TMP_InputField inputBox;

    private bool paused;
    private bool gameOver;

    private void Start()
    {
        pauseMenuObject.SetActive(false);
        gameOverMenu.SetActive(false);
        highScoreMenu.SetActive(false);
        paused = false;
        gameOver = false;
    }

    private void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if(!gameOver && Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }

        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }

    public void GameOver()
    {
        gameOver = true;

        highScoreNumText.text = scoreSystem.LoadHighScore().ToString();
        yourScoreNumText.text = scoreSystem.GetPlayerScore().ToString();

        gameOverMenu.SetActive(true);
        if(scoreSystem.GetPlayerScore() > scoreSystem.LoadHighScore())
        {
            highScoreMenu.SetActive(true);
            inputBox.onEndEdit.AddListener(SubmitName);
        }
    }

    private void SubmitName(string playerName)
    {
        scoreSystem.SaveScore(scoreSystem.GetPlayerScore(), playerName);
        highScoreMenu.SetActive(false);
    }

    public void OnResumeButtonClick()
    {
        PauseGame();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameUITestScene");
    }

    public void OnQuitButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void PauseGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenuObject.SetActive(false);
        }
        else
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenuObject.SetActive(true);
        }
    }
}
