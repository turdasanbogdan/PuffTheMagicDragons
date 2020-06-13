using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseedMenuUI;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameisPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
         pauseedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause(){
        pauseedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu(){
       SceneManager.LoadScene(0);
    }

    public void QuitGame(){
       Debug.Log("Quit Game");
       Application.Quit();
    }
}
