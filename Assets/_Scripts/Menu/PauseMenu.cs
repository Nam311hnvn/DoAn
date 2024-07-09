using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gamePauseUI;

    public void Pause()
    {
        gamePauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

     public void Continue()
    {
        gamePauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnRestartClicked()
    {
        Debug.Log("Restart Clicked");
        SceneManager.LoadSceneAsync("GameplayScene1");
        Time.timeScale = 1f;
    }

    public void OnMainMenuClicked()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1f;
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
