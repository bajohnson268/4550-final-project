using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    // Pause menu toggle is below.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

    // Toggles the pause menu to on/off.
    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // The pause menu is activated.
    void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // Loads the game menu scene.
    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Menu");
    }
    // Quits the game.
    public void QuitGame() 
    {
        Debug.Log("Quitting game... ");
        Application.Quit();
    }
}
