using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlessingTrigger : MonoBehaviour
{
    [SerializeField] GameObject gameObj;
    public int Count=0;
    GameObject[] enemyCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (collision.tag == "Player" && Count == 0 && enemyCount.Length == 0)
        {
            gameObj.SetActive(true);
            PauseGame();
            Count += 1;
        }

    }
    
    public void OnClickButton()
    {
        gameObj.SetActive(false);     
        ResumeGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }
}
