using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Project: JumpyStreet
/// Name: Jacob Frigon
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
public class PlayOnActive : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("GameScene");
    }
}
