using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PauseMenuScreen pauseMenu;
    [SerializeField] private GoalMenuScreen goalMenu;
    [SerializeField] private DeathMenuScreen deathMenu;

    private int HP;
    public int score;

    void Start()
    {
        score = 0;

        HPText.text = "HP: " + HP + " / 9999";
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.IsActive() && !goalMenu.IsActive())
        {
            SetGameActive(false);
            pauseMenu.Open();
        }
    }

    public void UpdateHP(int damage)
    {
        HP -= damage;
        HPText.text = "HP: " + HP.ToString() + "/ 9999"; 
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHP(int health)
    {
        HP = health;
    }

    public int GetHP()
    {
        return HP;
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void SetupGoalMenu()
    {
        goalMenu.Open(score);
        SetGameActive(false);
    }

    public void setupDeathMenu()
    {
        deathMenu.Setup(score);
    }

}
