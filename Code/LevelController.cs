using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static bool finished = false;
    public static int level = 1;

    public GameObject victoryPanel;
    public GameObject defeatPanel;
    
    private void Awake()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }
    private void Start()
    {
        finished = false;
    }
    private void Update()
    {
        if(finished == false)
        {
            Check();
        }
    }
    public void Check()
    {
        if (EnemySpawner.spawnCounter <= 0)
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();
 
            if (enemies.Length <= 0)
            {
                Victory();
 
            }
        } 
        if(Corn.singleton.health <= 0)
        {
            Defeat();
        }
    }
    public void Victory()
    {
        finished = true;
        level ++;
        GameController.SaveGame();
        victoryPanel.SetActive(true);
    }
 
    public void Defeat()
    {
        finished = true;
        level = 1;
        defeatPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
