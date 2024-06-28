using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelMove : MonoBehaviour
{
    public int levelMap;
    public int sceneBuildIndex;
    private int countMap = 2;
    GameObject[] enemyCount;   



    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Enter");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");

        if (other.tag == "Player" && enemyCount.Length == 0)
        {
            sceneBuildIndex = RandomMap();
            print("Switching Scene to " + sceneBuildIndex);
            
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    }

    public int RandomMap()
    {
        if (levelMap == 1)
        {
            return Random.Range(2,4);
            
        }
        else if (levelMap == 2)
        {
            return Random.Range(4,6);
            
        }
        else
        {
            return 9;        
        }
    }
}
