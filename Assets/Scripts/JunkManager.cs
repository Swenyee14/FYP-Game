using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JunkManager : MonoBehaviour
{
    public static JunkManager instance;
    private int junkFood;
    [SerializeField] private TMP_Text showJunkFood;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        showJunkFood.text = junkFood.ToString();
    }

    public void ChangeJunk(int num)
    {
        junkFood += num;
    }
}
