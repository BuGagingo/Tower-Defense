using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UM
{

    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager um;
        #region Health
        [Header("Health")]
        public int initHealth = 10;
        public int healthPerUpgrade = 5;
        public int healthGradePrice;
        public int healthGrade;
        public Text healthGradePriceText;
        #endregion
        #region Crystals
        [Header("Crystals")]
        public int initCrystals = 1;
        public int crystalsPerUpgrade = 2;
        #endregion
        #region Damage
        [Header("Damage")]
        public int initDamage = 1;
        public int damagePerUpgrade = 2;
        #endregion
        #region AttackSpeed
        [Header("AttackSpeed")]
        public int initAttackSpeed = 1;
        public int attackSpeedPerUpgrade = 2;
        #endregion
        void Awake()
        {
            um = this;
        }
        
    
        private void Update()
        {
            healthGradePriceText.text = healthGradePrice.ToString();
        }
        public void OnClickUpgradeHealth()
        {
            if(Corn.singleton.crystals >= healthGradePrice)
            {
                healthGrade = PlayerPrefs.GetInt("healthGrade", 0);
                healthGrade += 1;
                GameController.SaveHealthGrade();

                Corn.singleton.DecCrystals(healthGradePrice);
            }
        }
    }
}