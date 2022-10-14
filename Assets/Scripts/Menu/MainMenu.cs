using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CargarNivel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}

