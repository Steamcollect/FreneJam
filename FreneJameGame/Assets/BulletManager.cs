using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<Bullet> bullets;

    private void FixedUpdate()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                bullets[i].rb.velocity = bullets[i].transform.up * bullets[i].moveSpeed;
            }
            else
            {
                bullets.Remove(bullets[i]);
                i -= 1;
            }
        }
    }
}