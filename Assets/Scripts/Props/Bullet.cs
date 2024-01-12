using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string targetTag;

    public float attackDamage;
    public float moveSpeed;
    public int maxPenetration = 1;
    int enemyTouchCount = 0;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            collision.GetComponent<EntityHealth>().TakeDamage(attackDamage);
            enemyTouchCount++;

            if (enemyTouchCount >= maxPenetration) Destroy(gameObject);
        }
    }
}