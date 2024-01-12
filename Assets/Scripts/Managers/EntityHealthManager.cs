using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthManager : MonoBehaviour
{
    public List<EntityHealth> entitys;

    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (entitys.Count == 0) return;

        for (int i = 0; i < entitys.Count; i++)
        {
            if (entitys[i] != null)
            {
                entitys[i].healthSlider.transform.position = cam.WorldToScreenPoint(entitys[i].healthBarPos.position);
            }
            else
            {
                entitys.Remove(entitys[i]);
                i -= 1;
            }
        }
    }
}