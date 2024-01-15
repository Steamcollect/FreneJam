using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyController> enemys;
    GameObject player;
    GameStateManager gameStateManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void Update()
    {
        if (enemys.Count == 0 || player == null || gameStateManager.gameState == GameState.Paused) return;

        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] != null)
            {
                float distanceFromPlayer = Vector2.Distance(enemys[i].transform.position, player.transform.position);

                if (distanceFromPlayer > 25)
                {
                    float posX = (enemys[i].transform.position.x - player.transform.position.x) * .9f * -1;
                    float posY = (enemys[i].transform.position.y - player.transform.position.y) * .9f * -1;
                    enemys[i].transform.position = player.transform.position + new Vector3(posX, posY);
                }

                Vector2 lookDir = player.transform.position - enemys[i].transform.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                enemys[i].rotationPoint.rotation = Quaternion.Euler(0, 0, angle);

                if (distanceFromPlayer >= enemys[i].attackRange) enemys[i].transform.position = Vector2.SmoothDamp(enemys[i].transform.position, player.transform.position, ref enemys[i].velocity, distanceFromPlayer / enemys[i].moveSpeed);
                else if(distanceFromPlayer < enemys[i].attackRange && enemys[i].canAttack) enemys[i].Attack();
            }
            else
            {
                enemys.Remove(enemys[i]);
                i -= 1;
            }
        }
    }
}