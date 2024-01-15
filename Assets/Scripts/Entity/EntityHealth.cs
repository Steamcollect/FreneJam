using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EntityHealth : MonoBehaviour
{
    public Transform healthBarPos;
    public float maxHealth;
    public float xpGiven;
    public int scoreGiven;
    [HideInInspector]public float currentHealth;
    [HideInInspector] public Slider healthSlider;

    public bool isPlayer;

    public GameObject deathParticle;

    public GameObject healthBar;
    Transform canvas;
    EntityHealthManager entityHealthManager;
    PlayerXp scoreManager;
    PauseMenu pauseMenu;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        healthSlider = Instantiate(healthBar, canvas).GetComponent<Slider>();
        
        pauseMenu = FindFirstObjectByType<PauseMenu>();
        entityHealthManager = FindAnyObjectByType<EntityHealthManager>();
        scoreManager = FindAnyObjectByType<PlayerXp>();
        entityHealthManager.entitys.Add(this);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if(currentHealth <= 0)
        {
            Die();
            return;
        }

        float tmp = healthSlider.value;
        DOTween.To(() => tmp, x => tmp = x, currentHealth, .1f)
            .OnUpdate(() => {
                healthSlider.value = tmp;
            });
    }

    public void GiveHealth(float healthGiven)
    {
        currentHealth += healthGiven;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void Die()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);

        if (isPlayer) pauseMenu.OpenGameOverPanel();
        else scoreManager.TakeXp(xpGiven, scoreGiven, transform.position);

        Destroy(healthSlider.gameObject, .01f) ;
        Destroy(gameObject);
    }
}