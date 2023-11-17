using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UM;

public class Corn : MonoBehaviour
{
    public static Corn singleton;
    public float health = 10;
    public int crystals = 0;
 
    private void Awake()
    {
        singleton = this;
        crystals = PlayerPrefs.GetInt("crystals", 0);
        health = UpgradeManager.um.initHealth + UpgradeManager.um.healthPerUpgrade * PlayerPrefs.GetInt("healthGrade", 0);
    }
    
    public void TakeDamage(float dmg)
    {
        if (health > 0)
            health -= dmg;
 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddCrystals(int count)
    {
        crystals += count;
        GameController.SaveCrystals();
    }
    public void DecCrystals(int count)
    {
        crystals -= count;
        GameController.SaveCrystals();
    }
}

