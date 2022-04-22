using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    bool isCollected = false;
    int points = 50;

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isCollected = true;
            Debug.Log("Coin collected");
            Destroy(gameObject);
        }   
    }
}
