using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject resumeMenu;

    private bool isPause = false;// default boolean

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPause) //p pause in game
        { 
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R) && isPause) //r resume when pausing
        {
            ResumeGame();
        }


    }
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  - 1);
        Time.timeScale = 1f;
    }
    public void ExitGame() 
    {
        Application.Quit();
    }

    public void UIEnable() 
    {
        GameObject.Find("Canvas/panel/UI").SetActive(true);
    }

   public void PauseGame ()
    {
         pauseMenu.SetActive(true);
         Time.timeScale = 0f;
         isPause = true;
    }

    public void ResumeGame() 
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
}
