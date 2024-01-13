using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float moveSpeed = .2f;

    Transform player;
    Vector3 posOffset = new Vector3(0,0,-10);
    Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(player != null) transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, moveSpeed);
    }
}
