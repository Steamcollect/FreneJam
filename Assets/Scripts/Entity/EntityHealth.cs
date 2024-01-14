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
    [HideInInspector]public float currentHealth;
    [HideInInspector] public Slider healthSlider;

    public GameObject deathParticle;

    public GameObject healthBar;
    Transform canvas;
    EntityHealthManager entityHealthManager;
    PlayerXp scoreManager;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        healthSlider = Instantiate(healthBar, canvas).GetComponent<Slider>();
        
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
        scoreManager.TakeXp(xpGiven);
        Instantiate(deathParticle, transform.position, Quaternion.identity);

        Destroy(healthSlider.gameObject, .01f) ;
        Destroy(this.gameObject);
    }
}