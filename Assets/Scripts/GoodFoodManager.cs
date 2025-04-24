using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodFoodManager : MonoBehaviour
{
    public static GoodFoodManager instance;
    private int goodFood;
    [SerializeField] private TMP_Text showGoodFood;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        showGoodFood.text = goodFood.ToString();
    }

    public void ChangeGoodFood(int num)
    {
        goodFood += num;
    }
}
