using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Goal : MonoBehaviour
{
    [SerializeField] public UIManager UIManager;

    bool goalReached = false;
    int points = 10000;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            goalReached = true;
            Debug.Log("Level complete");
            UIManager.UpdateScore(points);
        }
    }
}
