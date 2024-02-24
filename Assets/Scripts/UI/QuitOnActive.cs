using UnityEngine;

/// <summary>
/// Project: JumpyStreet
/// Name: Jacob Frigon
/// Section: SGD 285.4171
/// Instructor: Aurore Locklear
/// Date: 02/25/2024
/// </summary>
public class QuitOnActive : MonoBehaviour
{
    private void OnEnable()
    {
        Application.Quit();
    }
}
