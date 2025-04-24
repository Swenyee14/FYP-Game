using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    [SerializeField] private int value;
    private bool triggered;
    private JunkManager junkManager;

    private void Start()
    {
        junkManager = JunkManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            junkManager.ChangeJunk(value);
            Destroy(gameObject);
        }
    }
}
