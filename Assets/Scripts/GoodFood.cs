using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodFood : MonoBehaviour
{
    [SerializeField] private int value;
    private bool triggered;
    private GoodFoodManager goodFoodManager;

    private void Start()
    {
        goodFoodManager = GoodFoodManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !triggered)
        {
            triggered = true;
            goodFoodManager.ChangeGoodFood(value);
            Destroy(gameObject);
        }
    }
}