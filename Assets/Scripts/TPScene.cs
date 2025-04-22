using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //go next
            SceneControler.instance.NextLevel();
        }
    }
}
