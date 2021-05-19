using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightFadeController : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private Light light;
    [SerializeField] private float minimalFadeValue = 0;
    public static bool isFade;
    
    private void Update()
    {
        if(isFade && light.intensity > minimalFadeValue)
            light.intensity -= fadeSpeed * Time.deltaTime;
    }

    public static void FadeOut()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFade = true;
        }
    }
}
