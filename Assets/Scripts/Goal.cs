using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    bool goalReached = false;
    int points = 10000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player") && !goalReached)
        {
            goalReached = true;
            gameManager.GoalReached();
        }
    }
}
