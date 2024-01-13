using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUp : MonoBehaviour
{
    public int statsPointRemining;
    public TMP_Text reminingPointsTxt;

    int damagePoint, penetrationPoint, reloadPoint, bulletSpeedPoint, maxHealthPoint, moveSpeedPoint;
    public Slider damageSlider, penetrationSlider, reloadSlider, bulletSpeedSlider, maxHealthSlider, moveSpeedSlider;
    public GameObject damageButton, penetrationButton, reloadButton, bulletSpeedButton, maxHealthButton, moveSpeedButton;

    public Animator upgradePanelAnim;

    PlayerCombat playerCombat;
    PlayerController playerController;
    EntityHealth playerHealth;

    private void Awake()
    {
        playerCombat = FindFirstObjectByType<PlayerCombat>();
        playerController = FindFirstObjectByType<PlayerController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityHealth>();
    }

    public void OpenUpgradePanel()
    {
        statsPointRemining++;
        upgradePanelAnim.SetBool("IsIn", true);
        reminingPointsTxt.text = statsPointRemining.ToString();
    }
    void CloseUpgradePanel()
    {
        upgradePanelAnim.SetBool("IsIn", false);
    }

    public void AddPoint(int currentStat)
    {
        if (statsPointRemining <= 0) return;

        switch (currentStat)
        {
            case 0:
                if(damagePoint < 7)
                {
                    playerCombat.attackDamage += 5;
                    damagePoint++;
                    damageSlider.value = damagePoint;
                    if(damagePoint >= 7) damageButton.SetActive(false);
                }
                break;
            case 1:
                if (penetrationPoint < 7)
                {
                    playerCombat.bullletPenetration += 1;
                    penetrationPoint++;
                    penetrationSlider.value = penetrationPoint;
                    if (penetrationPoint >= 7) penetrationButton.SetActive(false);
                }
                break;
            case 2:
                if (reloadPoint < 7)
                {
                    playerCombat.attackRate *= .8f;
                    reloadPoint++;
                    reloadSlider.value = reloadPoint;
                    if (reloadPoint >= 7) reloadButton.SetActive(false);
                }
                break;
            case 3:
                if (bulletSpeedPoint < 7)
                {
                    playerCombat.bulletSpeed *= 1.14f;
                    bulletSpeedPoint++;
                    bulletSpeedSlider.value = bulletSpeedPoint;
                    if (bulletSpeedPoint >= 7) bulletSpeedButton.SetActive(false);
                }
                break;
            case 4:
                if (maxHealthPoint < 7)
                {
                    playerHealth.maxHealth *= 1.15f;
                    maxHealthPoint++;
                    maxHealthSlider.value = maxHealthPoint;
                    if (maxHealthPoint >= 7) maxHealthButton.SetActive(false);
                }
                break;
            case 5:
                if (moveSpeedPoint < 7)
                {
                    playerController.moveSpeed *= 1.08f;
                    moveSpeedPoint++;
                    moveSpeedSlider.value = moveSpeedPoint;
                    if (moveSpeedPoint >= 7) moveSpeedButton.SetActive(false);
                }
                break;
        }

        statsPointRemining--;
        reminingPointsTxt.text = statsPointRemining.ToString();
        if (statsPointRemining <= 0) CloseUpgradePanel();
    }
}