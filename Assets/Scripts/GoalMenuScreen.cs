using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalMenuScreen : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private UITimer timer;
    public TextMeshProUGUI scoreText;

    int goalScore;
    int HPremain;
    int damageTaken;
    int timeInSeconds;
    int timeBonus;
    int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }

    public void Open(int score)
    {
        highScore = PlayerPrefs.GetInt("highscore", highScore);

        goalScore = CalcScore(score);
        UIManager.SetScore(goalScore);
        gameObject.SetActive(true);
        scoreText.text = "Score: " + goalScore.ToString();

        if (goalScore > highScore)
        {
            highScore = goalScore;

            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save();
        }
    }

    public int CalcScore(int finalScore)
    {
        HPremain = UIManager.GetHP();
        timeInSeconds = timer.GetSeconds();

        if (timeInSeconds < 12)
        {
            timeBonus = 4000;
        }
        else if (timeInSeconds < 14)
        {
            timeBonus = 2000;
        }
        else if (timeInSeconds < 18)
        {
            timeBonus = 1000;
        }
        else if (timeInSeconds < 19)
        {
            timeBonus = 500;
        }
        else if (timeInSeconds < 20)
        {
            timeBonus = 0;
        }
        else if (timeInSeconds < 27)
        {
            timeBonus = -2000;
        }
        else
        {
            timeBonus = -6000;
        }

        finalScore = finalScore + timeBonus;

        return finalScore;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level0");
        UIManager.SetGameActive(true);

        Close();
    }
}
