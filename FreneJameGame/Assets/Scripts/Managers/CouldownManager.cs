using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldownManager : MonoBehaviour
{
    public IEnumerator Wait(System.Action<bool> currentBool, float delay)
    {
        currentBool(false);
        yield return new WaitForSeconds(delay);
        currentBool(true);
    }
}