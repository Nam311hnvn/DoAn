using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void OnRestartClicked()
    {
        Debug.Log("Restart Clicked");
        SceneManager.LoadSceneAsync("GameplayScene1");
    }

    public void OnMainMenuClicked()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
