using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnActive : MonoBehaviour
{
    private void OnEnable()
    {
        Application.Quit();
    }
}
