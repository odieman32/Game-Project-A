using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Start Game!");
        //Loads the sceane corresponding by number
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        //quits out of the application and logs quit game
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
