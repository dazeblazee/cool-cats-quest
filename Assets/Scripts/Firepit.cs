using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepit : MonoBehaviour
{
    public GameManager gameManager;

    int damageDone = 20;
    float fireDamageDelay = 0.1f;
    bool inFirepit = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            inFirepit = true;
            StartCoroutine(InFire());
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            inFirepit = false;
        }
    }

    IEnumerator InFire()
    {
        while (inFirepit) {
            gameManager.PlayerDamageTaken(damageDone);
            yield return new WaitForSeconds(fireDamageDelay);
        }
    }
}
