using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public Animator upgradePanelAnim;
    public TMP_Text scoreTxt;

    public AudioMixer audioMixer;

    public bool isDead = false;
    public bool isOnMenu = false;

    PlayerLevelUp playerLevelUp;
    GameStateManager gameStateManager;
    PlayerXp playerXp;

    private void Awake()
    {
        playerLevelUp = FindFirstObjectByType<PlayerLevelUp>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();
        playerXp = FindFirstObjectByType<PlayerXp>();
    }

    private void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)) && !isDead)
        {
            switch (gameStateManager.gameState)
            {
                case GameState.Gameplay:
                    Pause();
                    break;
                case GameState.Paused:
                    Resume();
                    break;
            }
        }
    }

    public void Resume()
    {
        isOnMenu = false;

        gameStateManager.ResumeGameState();

        pausePanel.SetActive(false);
        if(playerLevelUp.statsPointRemining <= 0) upgradePanelAnim.SetBool("IsIn", false);
    }
    public void Pause()
    {
        isOnMenu = true;

        gameStateManager.PauseGameState();

        pausePanel.SetActive(true);
        upgradePanelAnim.SetBool("IsIn", true);
    }

    public void OpenGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
        upgradePanelAnim.SetBool("IsIn", true);
        isDead = true;

        StartCoroutine(SetScoreTxt());
    }

    IEnumerator SetScoreTxt()
    {
        yield return new WaitForSeconds(.5f);

        int tmp = 0;
        DOTween.To(() => tmp, x => tmp = x, playerXp.currentScore, 3).SetEase(Ease.OutExpo)
                        .OnUpdate(() => {
                            scoreTxt.text = tmp.ToString() + " pts";
                        });
    }

    public void Retrybutton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MusicToggle(bool isOn)
    {
        audioMixer.SetFloat("Music", isOn ? 0 : -80);
    }public void SoundToggle(bool isOn)
    {
        audioMixer.SetFloat("Sound", isOn ? 0 : -80);
    }
    public void FullScreenToggle(bool isOn)
    {
        Screen.fullScreen = isOn;
    }
}