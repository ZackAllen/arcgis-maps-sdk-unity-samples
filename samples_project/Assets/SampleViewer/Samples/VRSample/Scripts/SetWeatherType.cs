using Esri.ArcGISMapsSDK.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using static UnityEngine.Rendering.DebugUI;

public class SetWeatherType : MonoBehaviour
{
    private Volume volume;
    private GameObject weatherParticles;
    private void Start()
    {
        weatherParticles = GameObject.FindWithTag("WeatherParticles");
        Invoke(nameof(GetVolume), 0.5f);
    }

    private void GetVolume()
    {
        volume = FindObjectOfType<Volume>();
        if (volume.sharedProfile.TryGet<VolumetricClouds>(out var clouds))
        {
            SetWeatherTypeFromIndex(0);
        }
    }

    public void SetWeatherTypeFromIndex(int index)
    {
        weatherParticles = weatherParticles ? weatherParticles : GameObject.FindWithTag("WeatherParticles");
        volume = volume ? volume : FindObjectOfType<Volume>();
        if (index == 0)
        {
            weatherParticles.SetActive(false);
            if (volume.sharedProfile.TryGet<VolumetricClouds>(out var clouds))
            {
                clouds.enable.overrideState = true;
                clouds.enable.value = false;
                Debug.Log("turn off clouds");
            }
        }
        else if (index == 1)
        {
            weatherParticles.SetActive(true);
            if (volume.sharedProfile.TryGet<VolumetricClouds>(out var clouds))
            {
                clouds.enable.overrideState = true;
                clouds.enable.value = true;
                Debug.Log("turn on clouds");
            }
        }
    }
}
