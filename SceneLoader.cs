using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    const string CORE_GAME = "Game";

    public void LoadGame()
    {
        SceneManager.LoadScene(CORE_GAME);
    }
   
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
