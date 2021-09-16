using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Single Player");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
