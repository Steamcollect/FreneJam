using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<Bullet> bullets;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
                else bullets[i].rb.velocity = bullets[i].transform.up * bullets[i].moveSpeed;
            }
            else
            {
                bullets.Remove(bullets[i]);
                i -= 1;
            }
        }
    }
}