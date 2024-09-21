using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class LightingManager : MonoBehaviour
{
    public LightingSettings lightingSettings; // —сылка на Lighting Settings Asset

    private void Start()
    {
        ApplyLightingSettings();
    }

    private void ApplyLightingSettings()
    {
        if (lightingSettings != null)
        {
            Lightmapping.lightingSettings = lightingSettings;
        }
    }
}
