
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] Level currentLevelData;
    [SerializeField] Slider bossHealth;
    [SerializeField] TextMeshProUGUI bossName;
    [SerializeField] Weapons_Data currentWeaponData;
    [SerializeField] Image bossPortrait;
    [SerializeField] TextMeshProUGUI bossElement;
    [SerializeField] TextMeshProUGUI damageDone;
    [SerializeField] Slider levelTimer;
    private float totalLevelTime;
    [SerializeField] GameObject gameCompletedPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI weaponText;




    private int bossCurrentHP;
    private void Start()
    {
        bossCurrentHP = currentLevelData.Boss.BossHealth;
        UpdateBossPanelInfo();
        totalLevelTime = currentLevelData.LevelTime;
        UpdateWeaponDisplay(currentWeaponData);
    }
    

    public void GetLevelData(Level newLevel)
    {
        currentLevelData = newLevel;
        UpdateHealthDisplay(currentLevelData.Boss.BossHealth);
        UpdateBossPanelInfo();
        LevelText.SetText("Level: " + newLevel.LevelLoaded.ToString());
        totalLevelTime = currentLevelData.LevelTime;

    }

    public void UpdateDamageLog(int damage)
    {
        damageDone.SetText("Damage: " + damage);
    }

    private void UpdateBossPanelInfo()
    {
        bossName.SetText(currentLevelData.Boss.BossName);
        bossPortrait.sprite = currentLevelData.Boss.BossImage;
        bossElement.SetText("Boss Element: " + currentLevelData.Boss.BossAttribute.ToString());
    }

    public void UpdateHealthDisplay(int newHealth)
    {
        if (newHealth <= 0)
            bossCurrentHP = 0;
        else if (newHealth > currentLevelData.Boss.BossHealth)
            bossCurrentHP = currentLevelData.Boss.BossHealth;

        bossCurrentHP = newHealth;
        bossHealth.value = (float)bossCurrentHP / (float)currentLevelData.Boss.BossHealth;
    }

    public void UpdateTimer(int newTime)
    {
        levelTimer.value = (totalLevelTime - newTime) / totalLevelTime;
    }

    public void UpdateWeaponDisplay(Weapons_Data weapon)
    {
        var currentWeaponData = weapon;
        weaponText.SetText("Selected: " + currentWeaponData.WeaponName + " Damage: " + currentWeaponData.WeaponDamage + " Element: " + currentWeaponData._element);
    }

    public void GameCompleted()
    {
        gameCompletedPanel.SetActive(true);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

    

