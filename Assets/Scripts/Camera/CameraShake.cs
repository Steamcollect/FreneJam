using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float startingIntensity;

    float shakeTimerTotal;
    float shakeTimer;

    public static CameraShake instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCam(float intensity, float time)
    {
        startingIntensity = intensity;

        shakeTimerTotal = time;
        shakeTimer = time;
    }
}
