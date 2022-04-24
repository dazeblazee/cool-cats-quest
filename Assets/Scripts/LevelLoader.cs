using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private bool playerFinished;

    public string levelToLoad;

    void Start()
    {
        playerFinished = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            playerFinished = true;
        }
    }
}
