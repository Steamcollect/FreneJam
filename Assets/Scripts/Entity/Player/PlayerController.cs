using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    float angle;

    public Transform rotationPoint;

    Vector2 moveInput;
    Vector2 mousePos;
    Vector2 lookDir;

    Rigidbody2D rb;
    Camera cam;
    GameStateManager gameStateManager;

    private void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        gameStateManager = FindFirstObjectByType<GameStateManager>();
    }

    private void Update()
    {
        if (gameStateManager.gameState == GameState.Paused) return;

        Rotate();
     
        GetInput();
    }
    private void FixedUpdate()
    {
        if (gameStateManager.gameState == GameState.Paused)
        {
            rb.velocity = Vector2.zero;
        }else Move();
    }

    void Move()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }
    void Rotate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        lookDir = mousePos - rb.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rotationPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void GetInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }
}
