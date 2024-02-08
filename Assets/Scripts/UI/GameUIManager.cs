using System.Collections;
using System.Collections.Generic;
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
    private Button resumeButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private GameObject pauseMenuObject;

    private bool paused;

    private void Start()
    {
        pauseMenuObject.SetActive(false);
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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
