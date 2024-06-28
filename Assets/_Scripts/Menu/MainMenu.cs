using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        Debug.Log("New Game Clicked");      
        SceneManager.LoadSceneAsync("GameplayScene1");
    }
}    

