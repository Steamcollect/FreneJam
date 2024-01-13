using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform groundRef1, groundRef2, groundRef3, groundRef4, groundRef5, groundRef6, groundRef7, groundRef8, groundRef9;

    public void ChangeGroundPos(Vector2 currengGroundPos)
    {
        groundRef1.position = currengGroundPos;
        groundRef2.position = new Vector2(currengGroundPos.x - 50, currengGroundPos.y);
        groundRef3.position = new Vector2(currengGroundPos.x + 50, currengGroundPos.y);
        groundRef4.position = new Vector2(currengGroundPos.x, currengGroundPos.y - 50);
        groundRef5.position = new Vector2(currengGroundPos.x, currengGroundPos.y + 50);
        groundRef6.position = new Vector2(currengGroundPos.x - 50, currengGroundPos.y - 50);
        groundRef7.position = new Vector2(currengGroundPos.x + 50, currengGroundPos.y + 50);
        groundRef8.position = new Vector2(currengGroundPos.x + 50, currengGroundPos.y - 50);
        groundRef9.position = new Vector2(currengGroundPos.x - 50, currengGroundPos.y + 50);
    }
}