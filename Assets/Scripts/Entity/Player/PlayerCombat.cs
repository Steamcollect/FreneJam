using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRate;
    public float attackDamage;
    public float bulletSpeed;
    public int bullletPenetration;

    [HideInInspector] public int currentAttackPointIndex = 0;

    bool canAttack = true;
    bool isClicking;

    public GameObject bulletPrefabs;

    public List<Transform> attackPoints;

    CouldownManager couldownManager;
    BulletManager bulletManager;

    private void Awake()
    {
        couldownManager = FindAnyObjectByType<CouldownManager>();
        bulletManager= FindAnyObjectByType<BulletManager>();
    }

    private void Update()
    {
        if(isClicking && canAttack) Attack();

        isClicking = Input.GetButton("Fire1");
    }

    void Attack()
    {
        StartCoroutine(couldownManager.Wait(value => canAttack = value, attackRate));

        Bullet currentBullet = Instantiate(bulletPrefabs, attackPoints[currentAttackPointIndex].position, attackPoints[currentAttackPointIndex].rotation).GetComponent<Bullet>();
        currentBullet.targetTag = "Enemy";
        currentBullet.attackDamage = attackDamage;
        currentBullet.maxPenetration = bullletPenetration;
        currentBullet.moveSpeed = bulletSpeed;
        bulletManager.bullets.Add(currentBullet);

        currentAttackPointIndex = (currentAttackPointIndex + 1) % attackPoints.Count;
    }
}