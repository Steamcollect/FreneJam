using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float attackDamage;
    public float attackRange;
    public float bulletSpeed;


    public float attackRate;
    [HideInInspector]public bool canAttack = true;

    public Transform rotationPoint;
    public Transform[] attackPoints;

    public GameObject bulletPrefabs;

    [HideInInspector]public BulletManager bulletManager;
    [HideInInspector]public CouldownManager couldownManager;

    private void Awake()
    {
        bulletManager = FindFirstObjectByType<BulletManager>();
        couldownManager = FindFirstObjectByType<CouldownManager>();
    }

    public abstract void Attack();

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}