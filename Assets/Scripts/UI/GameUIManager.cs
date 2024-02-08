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

    private bool paused;
    private bool gameOver;

    private void Start()
    {
        pauseMenuObject.SetActive(false);
        gameOverMenu.SetActive(false);
        paused = false;
        gameOver = false;
    }

    private void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);

    }

    public void OnResumeButtonClick()
    {
        PauseGame();
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitButtonClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    private void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            pauseMenuObject.SetActive(true);
        }
        else if (paused)
        {
            paused = false;
            pauseMenuObject.SetActive(false);
        }
    }
}
