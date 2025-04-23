using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    Vector2 checkPointPos;

    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    private void Start()
    {
        checkPointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deathFloor"))
        {
            Die();
        }
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }

    void Die()
    {
        audioManager.PlaySFX(audioManager.death);
        StartCoroutine(RespawnAfterDelay(5f)); 
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        //disable movement or play death animation
        yield return new WaitForSeconds(delay);
        Respawn();
    }

    void Respawn()
    {
        transform.position = checkPointPos;
        audioManager.PlaySFX(audioManager.respawn);
    }
}
