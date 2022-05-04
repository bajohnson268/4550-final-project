using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public AudioSource gameMusic;
    public bool muteSfx = false;

    public List<GameObject> menuObjects;
    public List<GameObject> instructionsObjects;
    public List<GameObject> optionsObjects;

    // Toggles the menu visibility when needed.
    public void ToggleMenuVisibility()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Toggle reached the end of function.");
    }

    // Toggles the options menu visibility when needed.
    public void ToggleOptionsVisibility()
    {
        foreach (GameObject obj in optionsObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Options are gone.");
    }

    // Exits the game.
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    // Mutes the game music.
    public void MuteMusic()
    {
        gameMusic.mute = !gameMusic.mute;
    }
    // Mutes sfx
    public void MuteSFX()
    {
        muteSfx = !muteSfx;
    }
    // Loads the game menu scene to replay.
    public void ReloadGame()
    {
        SceneManager.LoadScene("Game Menu");
    }
    // Activates the game scene.
    public void OnPlay()
    {
        SceneManager.LoadScene("gameScene");
        Debug.Log("Loaded gameScene successfully. ");
    }

    private void DontDestroyOnLoad() 
    {
        Debug.Log("BRB");
    }

}

