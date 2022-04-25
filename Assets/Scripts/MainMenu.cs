using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    public int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = highScore.ToString();
    }

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
