using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionComp : MonoBehaviour
{
    GameController gameController;
    audioManager audioManager;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.sectionComplete);
        }
    }
}
