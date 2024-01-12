using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float maxXp;
    public float currentXp;
    public int currentLvl;

    public Slider xpSlider;
    public TMP_Text lvlTxt;

    LevelUpManager levelUpManager;

    private void Awake()
    {
        levelUpManager = FindFirstObjectByType<LevelUpManager>();
    }

    private void Start()
    {
        currentXp = 0;
        currentLvl = 1;
        lvlTxt.text = "lvl" + currentLvl.ToString();
        xpSlider.maxValue = maxXp;
        xpSlider.value = currentXp;
    }

    public void TakeXp(float xpGiven)
    {
        currentXp += xpGiven;

        if(currentXp >= maxXp)
        {
            float xpRemining = (maxXp - currentXp) * -1;

            currentLvl++;
            lvlTxt.text ="lvl" + currentLvl.ToString();
            currentXp = 0;
            maxXp *= 1.18f;
            TakeXp(xpRemining);

            levelUpManager.OpenUpgradePanel();
        }

        xpSlider.value = currentXp;
    }
}