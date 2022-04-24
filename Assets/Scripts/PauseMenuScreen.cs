using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuScreen : MonoBehaviour
{
    [SerializeField] private UIManager UIManager;

    public void Open()
    {
        gameObject.SetActive(true);
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

    public void ContinueButton()
    {
        UIManager.SetGameActive(true);

        Close();
    }
}
