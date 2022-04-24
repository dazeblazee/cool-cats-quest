using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathMenuScreen : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;
    public TextMeshProUGUI scoreText;

    public void Setup(int score)
    {
        UIManager.SetGameActive(false);
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    public void RetryButton()
    {
        UIManager.SetGameActive(true);
        SceneManager.LoadScene("Level0");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Title");
    }
}
