using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Wait for use to press P to pause the game or unpause it
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume function. Made public so that buttons can access function
    public void Resume()
    {
        Debug.Log("Resuming");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pause function
    void Pause()
    {
        Debug.Log("Paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Quit function
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
