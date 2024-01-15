using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRate;
    public float attackDamage;
    public float bulletSpeed;
    public int bullletPenetration;

    public AudioClip[] attackSounds;

    [HideInInspector] public int currentAttackPointIndex = 0;

    bool canAttack = true;
    bool isClicking;

    public GameObject bulletPrefabs;

    public List<Transform> attackPoints;

    AudioManager audioManager;
    CouldownManager couldownManager;
    BulletManager bulletManager;
    GameStateManager gameStateManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        couldownManager = FindAnyObjectByType<CouldownManager>();
        bulletManager= FindAnyObjectByType<BulletManager>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void Update()
    {
        if (gameStateManager.gameState == GameState.Paused) return;

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

        audioManager.PlayClipAt(transform.position, attackSounds[Random.Range(0, attackSounds.Length)]);

        currentAttackPointIndex = (currentAttackPointIndex + 1) % attackPoints.Count;
    }
}