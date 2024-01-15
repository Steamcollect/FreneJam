using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float moveSpeed = .2f;

    Vector3 posOffset = new Vector3(0,0,-10);
    Vector3 velocity = Vector3.zero;

    Transform player;
    GameStateManager gameStateManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void Update()
    {
        if(player != null && gameStateManager.gameState == GameState.Gameplay)
            transform.position = Vector3.SmoothDamp(transform.position, player.position + posOffset, ref velocity, moveSpeed);
    }
}