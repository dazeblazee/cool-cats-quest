using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject currentCheckpoint;
    [SerializeField] public UIManager UIManager;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    private PlayerController player;
    private int respawnDelay = 2;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        PlayerController playerController = player.GetComponent<PlayerController>();
        UIManager.SetHP(playerController.health);
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        UIManager.ResetScore();
        yield return new WaitForSeconds(respawnDelay);
        Debug.Log("Player respawn");
        Application.LoadLevel(Application.loadedLevel);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

    public void PlayerDamageTaken(int damage)
    {
        player.Hit(damage);
        UIManager.UpdateHP(damage);
    }
}