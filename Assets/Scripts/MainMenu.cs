using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void exitGame()
    {
        Application.Quit();
    }

    public void tutorial()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
