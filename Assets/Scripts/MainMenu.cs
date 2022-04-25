using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //public string startLevel;

    public void NewGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Level0");

    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
