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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            isCollected = true;
            UIManager.UpdateScore(points);
            Destroy(gameObject);
        }   
    }
}
