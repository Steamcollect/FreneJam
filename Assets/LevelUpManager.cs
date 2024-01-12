using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public int statsPointRemining;

    int damagePoint, penetrationPoint, reloadPoint, bulletSpeedPoint, maxHealthPoint, moveSpeedPoint;
    public Slider damageSlider, penetrationSlider, reloadSlider, bulletSpeedSlider, maxHealthSlider, MoveSpeedSlider;

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
    }
    void CloseUpgradePanel()
    {
        upgradePanelAnim.SetBool("IsIn", false);
    }

    public void AddPoint(int currentStat)
    {
        switch (currentStat)
        {
            case 0:
                if(damagePoint < 7 && statsPointRemining > 0)
                {
                    playerCombat.attackDamage *= 1.15f;
                    damagePoint++;
                    damageSlider.value = damagePoint * 2;
                }
                break;
            case 1:
                if (penetrationPoint < 7 && statsPointRemining > 0)
                {
                    playerCombat.bullletPenetration += 1;
                    penetrationPoint++;
                    penetrationSlider.value = damagePoint * 2;
                }
                break;
            case 2:
                if (reloadPoint < 7 && statsPointRemining > 0)
                {
                    playerCombat.attackRate *= .8f;
                    reloadPoint++;
                    reloadSlider.value = reloadPoint * 2;
                }
                break;
            case 3:
                if (bulletSpeedPoint < 7 && statsPointRemining > 0)
                {
                    playerCombat.bulletSpeed *= 1.2f;
                    bulletSpeedPoint++;
                    bulletSpeedSlider.value = bulletSpeedPoint * 2;
                }
                break;
            case 4:
                if (maxHealthPoint < 7 && statsPointRemining > 0)
                {
                    playerHealth.maxHealth *= 1.15f;
                    maxHealthPoint++;
                    maxHealthSlider.value = maxHealthPoint * 2;
                }
                break;
            case 5:
                if (moveSpeedPoint < 7 && statsPointRemining > 0)
                {
                    playerController.moveSpeed *= 1.08f;
                    moveSpeedPoint++;
                    MoveSpeedSlider.value = moveSpeedPoint * 2;
                }
                break;
        }

        statsPointRemining--;
        playerHealth.GiveHealth(playerHealth.maxHealth * .2f);

        if (statsPointRemining <= 0) CloseUpgradePanel();
    }
}