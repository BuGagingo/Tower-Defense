using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UM;

public class GameController : MonoBehaviour
{
    public static void SaveGame()
    {
        SaveLevel();
        SaveCrystals();
        SaveHealthGrade();
    }
    public static void ClearGame()
    {
        ClearLevel();
        ClearCrystals();
        ClearHealthGrade();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void SaveLevel()
    {
        PlayerPrefs.SetInt("level", LevelController.level);
    }
 
    public static void ClearLevel()
    {
        PlayerPrefs.SetInt("level", 1);
    }

    public static void SaveCrystals()
    {
        PlayerPrefs.SetInt("crystals", Corn.singleton.crystals);
    }
 
    public static void ClearCrystals()
    {
        PlayerPrefs.SetInt("crystals", 0);
    }

    public static void SaveHealthGrade()
    {
        PlayerPrefs.SetInt("healthGrade", UpgradeManager.um.healthGrade);
    }

    public static void ClearHealthGrade()
    {
        PlayerPrefs.SetInt("healthGrade", 0);
    }
}
