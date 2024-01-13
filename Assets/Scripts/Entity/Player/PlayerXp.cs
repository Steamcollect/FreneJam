using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerXp : MonoBehaviour
{
    public float maxXp;
    public float currentXp;
    public int currentLvl;

    public Slider xpSlider;
    public TMP_Text lvlTxt;

    public GameObject playerCanon1;
    public GameObject playerCanon2;
    public List<Transform> playerAttackPoints2;
    public GameObject playerCanon3;
    public List<Transform> playerAttackPoints3;
    public GameObject playerCanon4;
    public List<Transform> playerAttackPoints4;

    PlayerLevelUp levelUpManager;
    EnemySpawner enemySpawner;
    EntityHealth playerHealth;
    PlayerCombat playerCombat;

    private void Awake()
    {
        levelUpManager = FindFirstObjectByType<PlayerLevelUp>();
        playerCombat = FindFirstObjectByType<PlayerCombat>();
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityHealth>();
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
            xpSlider.maxValue = maxXp;
            xpSlider.value = currentXp;
            TakeXp(xpRemining);

            switch (currentLvl)
            {
                case 3:
                    enemySpawner.enemySpawnStats[1].haveTheLevelToSpawn = true;
                    break;
                case 5:
                    enemySpawner.enemySpawnStats[2].haveTheLevelToSpawn = true;
                    break;
                case 10:
                    enemySpawner.enemySpawnStats[3].haveTheLevelToSpawn = true;
                    enemySpawner.enemySpawnStats[4].haveTheLevelToSpawn = true;

                    playerCanon1.SetActive(false);
                    playerCanon2.SetActive(true);
                    playerCombat.attackPoints = playerAttackPoints2;
                    playerCombat.attackRate *= .5f;
                    playerCombat.currentAttackPointIndex = 0;
                    break;
                case 15:
                    enemySpawner.enemySpawnStats[5].haveTheLevelToSpawn = true;
                    enemySpawner.enemySpawnStats[6].haveTheLevelToSpawn = true;
                    break;
                case 20:
                    enemySpawner.enemySpawnStats[7].haveTheLevelToSpawn = true;

                    playerCanon2.SetActive(false);
                    playerCanon3.SetActive(true);
                    playerCombat.attackPoints = playerAttackPoints3;
                    playerCombat.attackRate *= .5f;
                    playerCombat.currentAttackPointIndex = 0;
                    break;
                case 30:
                    playerCanon3.SetActive(false);
                    playerCanon4.SetActive(true);
                    playerCombat.attackPoints = playerAttackPoints4;
                    playerCombat.attackRate *= .5f;
                    playerCombat.currentAttackPointIndex = 0;
                    break;
            }

            for (int i = 0; i < enemySpawner.enemySpawnStats.Length; i++)
            {
                if (enemySpawner.enemySpawnStats[i].haveTheLevelToSpawn) enemySpawner.enemySpawnStats[i].spawningDelay *= .98f;
            }
            playerHealth.GiveHealth(playerHealth.maxHealth * .1f);
            levelUpManager.OpenUpgradePanel();
        }

        xpSlider.value = currentXp;
    }
}