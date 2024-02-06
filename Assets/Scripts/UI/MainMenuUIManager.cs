using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button instrucButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button backButton;

    private void Start()
    {
        this.playButton.enabled = true;
        this.instrucButton.enabled = true;
        this.quitButton.enabled = true;
    }

    public void OnPlayButtonClick()
    {
        this.playButton.enabled = false;
        SceneManager.LoadScene("GameScene");
    }

    public void OnInstructButtonClick()
    {
        this.instrucButton.enabled = false;
        //TODO: Show Instruciton Panel
    }

    public void OnBackButtonClick()
    {

    }

    public void OnQuitButtonClick()
    {
        this.quitButton.enabled = false;
        Application.Quit();
    }
}
