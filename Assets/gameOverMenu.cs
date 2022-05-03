using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{

    private void Start()
    {

        //SceneManager.MoveGameObjectToScene(GameObject.Find("deck"), SceneManager.GetActiveScene());
        //SceneManager.MoveGameObjectToScene(GameObject.Find("hand"), SceneManager.GetActiveScene());

        Destroy(GameObject.Find("deck"));
        Destroy(GameObject.Find("hand"));


    }

    public void onPlayAgain() {

        SceneManager.LoadScene("gameScene");
    
    }

    public void quit()
    {

        Application.Quit();

    }

    public void mainMenu() {

        SceneManager.LoadScene("Game Menu");

    }

}
