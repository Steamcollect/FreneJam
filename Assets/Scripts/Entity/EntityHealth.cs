using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour
{
    public Transform healthBarPos;
    public float maxHealth;
    public float xpGiven;
    [HideInInspector]public float currentHealth;
    [HideInInspector] public Slider healthSlider;
    
    public GameObject healthBar;
    Transform canvas;
    EntityHealthManager entityHealthManager;
    ScoreManager scoreManager;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        healthSlider = Instantiate(healthBar, canvas).GetComponent<Slider>();
        
        entityHealthManager = FindAnyObjectByType<EntityHealthManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
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

        healthSlider.value = currentHealth;
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

        Destroy(healthSlider.gameObject);
        Destroy(this.gameObject);
    }
}