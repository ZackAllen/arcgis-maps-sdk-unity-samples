using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Esri.ArcGISMapsSDK.Components;
using Esri.ArcGISMapsSDK.Utils.GeoCoord;
using Esri.GameEngine.Geometry;

// A custom struct to hold data regarding ArcGIS map component positions
public struct coordinates
{
    public float longi;
    public float lati;

    // Constructor
    public coordinates(float longi, float lati)
    {
        this.longi = longi;
        this.lati = lati;
    }
}

public class LocationSelector : MonoBehaviour
{
    private ArcGISMapComponent arcGISMapComponent;

    // List of coordinates to set to ArcGIS Map origin, leading to 3D city scene layers collected by Esri
    private List<coordinates> spawnLocations = new List<coordinates> {new coordinates(-122.4194f, 37.7749f), new coordinates(2.8234f, 41.984f),
    new coordinates(172.64f, -43.534f), new coordinates(-73.5674f, 45.5019f)};

    void Start()
    {
        arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();
        
        // Get a random set of coordinates from the list to spawn user in unique location
        coordinates spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
        SetNewArcGISMapOrigin(spawnLocation.longi, spawnLocation.lati);
    }

    private void SetNewArcGISMapOrigin(float longitutde, float latitude)
    {
        if (!arcGISMapComponent)
        {
            arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();
        }
        arcGISMapComponent.OriginPosition = new ArcGISPoint(longitutde, latitude, 0, ArcGISSpatialReference.WGS84());
    }
}
