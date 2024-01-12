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

    private void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
     
        GetInput();
    }
    private void FixedUpdate()
    {
        Move();
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
