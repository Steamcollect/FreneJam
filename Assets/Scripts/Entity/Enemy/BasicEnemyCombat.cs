using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCombat : EnemyController
{
    public override void Attack()
    {
        StartCoroutine(couldownManager.Wait(value => canAttack = value, attackRate));

        for (int i = 0; i < attackPoints.Length; i++)
        {
            Bullet currentBullet = Instantiate(bulletPrefabs, attackPoints[i].position, attackPoints[i].rotation).GetComponent<Bullet>();
            currentBullet.targetTag = "Player";
            currentBullet.attackDamage = attackDamage;
            currentBullet.maxPenetration = 1;
            currentBullet.moveSpeed = bulletSpeed;
            bulletManager.bullets.Add(currentBullet);
        }
    }
}