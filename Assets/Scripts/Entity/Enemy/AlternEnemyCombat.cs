using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternEnemyCombat : EnemyController
{
    int currentAttackPointIndex = 0;

    public override void Attack()
    {
        StartCoroutine(couldownManager.Wait(value => canAttack = value, attackRate));

        Bullet currentBullet = Instantiate(bulletPrefabs, attackPoints[currentAttackPointIndex].position, attackPoints[currentAttackPointIndex].rotation).GetComponent<Bullet>();
        currentBullet.targetTag = "Player";
        currentBullet.attackDamage = attackDamage;
        currentBullet.maxPenetration = 1;
        currentBullet.moveSpeed = bulletSpeed;
        bulletManager.bullets.Add(currentBullet);

        currentAttackPointIndex = (currentAttackPointIndex + 1) % attackPoints.Length;
    }
}
