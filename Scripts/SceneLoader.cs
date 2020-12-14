using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int plantsRemaining = 10;

    public void DecreasePlantsRemaining()
    {
        plantsRemaining--;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
        // potentially add a timescale = 1 here
    }

    public void Update()
    {
        if (plantsRemaining == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
