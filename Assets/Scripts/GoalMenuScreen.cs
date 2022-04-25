using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalMenuScreen : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    public TextMeshProUGUI scoreText;

    int goalScore;
    int HPremain;
    int damageTaken;

    public void Open(int score)
    {
        goalScore = CalcScore(score);
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Level complete");
    }

    public int CalcScore(int finalScore)
    {
        HPremain = UIManager.GetHP();
        goalScore = UIManager.GetScore();
        return goalScore;
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
