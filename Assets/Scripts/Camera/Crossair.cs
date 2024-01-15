using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossair : MonoBehaviour
{
    Camera cam;

    public float rotationSpeed;
    float angle;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Cursor.visible = false;

        transform.position = Input.mousePosition;

        angle -= Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0,0, angle);
    }
}