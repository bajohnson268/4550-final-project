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

    public void ToggleMenuVisibility()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Toggle reached the end of function.");
    }

    public void ToggleOptionsVisibility()
    {
        foreach (GameObject obj in optionsObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Options are gone.");
    }

    /*public void ToggleInstructionsVisibility()
    {
        foreach (GameObject obj in instructionsObjects)
        { 
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Successfully reached the end of the instructions visibility thingy.");
    }
    */

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void MuteMusic()
    {
        gameMusic.mute = !gameMusic.mute;
    }

    public void MuteSFX()
    {
        muteSfx = !muteSfx;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("gameScene");
        Debug.Log("Loaded gameScene successfully. ");
    }

    /*public void OnOptions() 
    {
        foreach (GameObject obj in instructionsObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
        Debug.Log("Successfully reached the end of the instructions visibility thingy.");
    }
    */

    private void DontDestroyOnLoad() 
    {
        Debug.Log("BRB");
    }

}

