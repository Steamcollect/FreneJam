using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRate;
    public float attackDamage;
    public float bulletSpeed;
    public int bullletPenetration;

    bool canAttack = true;
    bool isClicking;

    public GameObject bulletPrefabs;

    public Transform attackPoint;

    CameraShake camShake;
    CouldownManager couldownManager;
    BulletManager bulletManager;

    private void Awake()
    {
        camShake = FindAnyObjectByType<CameraShake>();
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

        Bullet currentBullet = Instantiate(bulletPrefabs, attackPoint.position, attackPoint.rotation).GetComponent<Bullet>();
        currentBullet.targetTag = "Enemy";
        currentBullet.attackDamage = attackDamage;
        currentBullet.maxPenetration = bullletPenetration;
        currentBullet.moveSpeed = bulletSpeed;
        bulletManager.bullets.Add(currentBullet);
    }
}