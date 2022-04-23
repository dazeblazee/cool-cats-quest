using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int HP;
    public int score;

    void Start()
    {
        score = 0;

        HPText.text = "HP: " + HP + " / 9999";
        scoreText.text = "Score: " + score;
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

    public void SetHP(int health)
    {
        HP = health;
    }

}
