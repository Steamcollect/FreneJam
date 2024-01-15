using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public TMP_Text text;
    public Camera cam;
    public Vector2 pos;

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(pos);
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}