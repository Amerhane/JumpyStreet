using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOnActive : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("GameUITestScene");
    }
}
