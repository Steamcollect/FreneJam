using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<Bullet> bullets;

    GameObject player;
    GameStateManager gameStateManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                if(player != null && Vector2.Distance(bullets[i].transform.position, player.transform.position) > 25)
                {
                    Destroy(bullets[i].gameObject);
                    bullets.Remove(bullets[i]);
                    i -= 1;
                }
                else
                {
                    if (gameStateManager.gameState == GameState.Gameplay) bullets[i].rb.velocity = bullets[i].transform.up * bullets[i].moveSpeed;
                    else bullets[i].rb.velocity = Vector2.zero;
                }
            }
            else
            {
                bullets.Remove(bullets[i]);
                i -= 1;
            }
        }
    }
}