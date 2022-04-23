using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] public UIManager UIManager;

    bool isCollected = false;
    int points = 200;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isCollected = true;
            UIManager.UpdateScore(points);
            Destroy(gameObject);
        }   
    }
}
