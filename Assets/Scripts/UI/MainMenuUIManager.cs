using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button instrucButton;
    [SerializeField]
    private Button quitButton;

    public void OnPlayButtonClick()
    {

    }

    public void OnInstructButtonClick()
    {

    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
