using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public float attackDamage;
    public float attackRange;

    public float attackRate;
    public bool canAttack;

    public Transform[] attackPoints;

    public void Attack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
