using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    Vector2 checkPointPos;
    SpriteRenderer sprite;

    audioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
        sprite = GetComponent<SpriteRenderer>();
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
        StartCoroutine(RespawnAfterDelay(1.25f));
        audioManager.PlaySFX(audioManager.death);
        sprite.enabled = false;
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
        sprite.enabled = true;
    }
}
