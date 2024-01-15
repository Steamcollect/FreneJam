using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerLevelUp : MonoBehaviour
{
    public int statsPointRemining;
    public TMP_Text reminingPointsTxt;

    int damagePoint, reloadPoint, bulletSpeedPoint, maxHealthPoint, moveSpeedPoint, visionPoint;
    public Slider damageSlider, reloadSlider, bulletSpeedSlider, maxHealthSlider, moveSpeedSlider, visionSlider;
    public GameObject damageButton, reloadButton, bulletSpeedButton, maxHealthButton, moveSpeedButton, visionButton;

    public Animator upgradePanelAnim;

    PlayerCombat playerCombat;
    PlayerController playerController;
    EntityHealth playerHealth;
    GameStateManager gameStateManager;
    PauseMenu pauseMenu;

    Camera cam;

    private void Awake()
    {
        playerCombat = FindFirstObjectByType<PlayerCombat>();
        playerController = FindFirstObjectByType<PlayerController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityHealth>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();
        pauseMenu = FindAnyObjectByType<PauseMenu>();

        cam = Camera.main;
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
        if (statsPointRemining <= 0 || pauseMenu.isDead) return;

        switch (currentStat)
        {
            case 0:
                if(damagePoint < 7)
                {
                    playerCombat.attackDamage += 5;
                    damagePoint++;
                    damageSlider.DOValue(damagePoint, .4f).SetEase(Ease.OutQuint);
                    if (damagePoint >= 7) damageButton.SetActive(false);
                }
                break;
            case 2:
                if (reloadPoint < 7)
                {
                    playerCombat.attackRate *= .8f;
                    reloadPoint++;
                    reloadSlider.DOValue(reloadPoint, .4f).SetEase(Ease.OutQuint);
                    if (reloadPoint >= 7) reloadButton.SetActive(false);
                }
                break;
            case 3:
                if (bulletSpeedPoint < 7)
                {
                    playerCombat.bulletSpeed *= 1.14f;
                    bulletSpeedPoint++;
                    bulletSpeedSlider.DOValue(bulletSpeedPoint, .4f).SetEase(Ease.OutQuint);
                    if (bulletSpeedPoint >= 7) bulletSpeedButton.SetActive(false);
                }
                break;
            case 4:
                if (maxHealthPoint < 7)
                {
                    playerHealth.maxHealth *= 1.15f;
                    maxHealthPoint++;
                    maxHealthSlider.DOValue(maxHealthPoint, .4f).SetEase(Ease.OutQuint);
                    if (maxHealthPoint >= 7) maxHealthButton.SetActive(false);
                }
                break;
            case 5:
                if (moveSpeedPoint < 7)
                {
                    playerController.moveSpeed *= 1.08f;
                    moveSpeedPoint++;
                    moveSpeedSlider.DOValue(moveSpeedPoint, .4f).SetEase(Ease.OutQuint);
                    if (moveSpeedPoint >= 7) moveSpeedButton.SetActive(false);
                }
                break;
            case 6:
                if (visionPoint < 7)
                {
                    float tmp = cam.orthographicSize;
                    DOTween.To(() => tmp, x => tmp = x, cam.orthographicSize * 1.07f, 1f)
                        .OnUpdate(() => {
                            cam.orthographicSize = tmp;
                        });

                    visionPoint++;
                    visionSlider.DOValue(visionPoint, .4f).SetEase(Ease.OutQuint);
                    if (moveSpeedPoint >= 7) visionButton.SetActive(false);
                }
                break;
        }

        statsPointRemining--;
        reminingPointsTxt.text = statsPointRemining.ToString();
        if (statsPointRemining <= 0 && gameStateManager.gameState == GameState.Gameplay) CloseUpgradePanel();
    }
}