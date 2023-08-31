using Esri.ArcGISMapsSDK.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class SetWeatherType : MonoBehaviour
{ 
    private GameObject weatherParticles;

    private void Start()
    {
        weatherParticles = GameObject.FindWithTag("WeatherParticles");

        // Delay on volume cache to give it time to instantiate
        SetWeatherTypeFromIndex(0);
    }


    public void SetWeatherTypeFromIndex(int index)
    {

        weatherParticles = weatherParticles ? weatherParticles : GameObject.FindWithTag("WeatherParticles");

        if (index == 0) //Sunny
        {
            weatherParticles.SetActive(false);
        }
        else if (index == 1) //Rainy
        {
            weatherParticles.SetActive(true);
        }
    }
}
