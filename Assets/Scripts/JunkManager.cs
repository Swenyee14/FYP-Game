using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JunkManager : MonoBehaviour
{
    public static JunkManager instance;
    private int junkFood;
    [SerializeField] private TMP_Text showJunkFood;
    [SerializeField] private GameObject gameOverScreen;

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

        if (junkFood == 15)
        {
            Debug.Log("failed");
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
