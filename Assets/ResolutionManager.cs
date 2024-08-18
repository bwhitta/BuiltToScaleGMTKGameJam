using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private float resolutionCheckCountdown = 0;
    private readonly int resolutionCheckFrequency = 1;
    public static float width, height;
    public static Vector2 Size => new(width, height);
    
    void Update()
    {
        resolutionCheckCountdown -= Time.deltaTime;
        if (resolutionCheckCountdown <= 0)
        {
            // For some reason Screen.currentResolution.height being in the RelativeCharacterHeight property makes things real jittery, so leave it in the update loop here.
            resolutionCheckCountdown = resolutionCheckFrequency;
            height = Screen.currentResolution.height;
            width = Screen.currentResolution.width;
        }

    }
}
