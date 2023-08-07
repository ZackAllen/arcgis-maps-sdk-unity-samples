using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Esri.ArcGISMapsSDK.Components;
using Esri.ArcGISMapsSDK.Utils.GeoCoord;
using Esri.GameEngine.Geometry;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEditor;

// A custom struct to hold data regarding ArcGIS map component positions
public struct coordinates
{
    public string name;
    public float longitutde;
    public float latitude;
    public float playerElevation;

    // Constructor
    public coordinates(string name, float longitutde, float latitude, float playerElevation)
    {
        this.name = name;
        this.longitutde = longitutde;
        this.latitude = latitude;
        this.playerElevation = playerElevation;
    }
}

public class LocationSelector : MonoBehaviour
{
    private ArcGISMapComponent arcGISMapComponent;
    private GameObject XROrigin;

    private GameObject menu;
    private GameObject menuManager;

    // List of coordinates to set to ArcGIS Map origin, leading to 3D city scene layers collected by Esri
    private List<coordinates> spawnLocations = new List<coordinates> {new coordinates("San Francisco", -122.4194f, 37.7749f, 150f), new coordinates("Girona, Spain", 2.8234f, 41.984f, 130f),
    new coordinates("Christchurch, New Zealand", 172.64f, -43.534f, 100f), new coordinates("Montreal, Canada", -73.5674f, 45.5019f, 110f),
    new coordinates("Fiordland National Park", 167.266693f, -45.440842f, 1600f), new coordinates("Mt Everest", 86.925f, 27.9881f, 8850f),
    new coordinates("Grand Canyon", -112.3535f, 36.2679f, 3000f)};

    void Start()
    {
        arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();
        XROrigin = FindObjectOfType<XROrigin>().gameObject;

        menu = GameObject.FindWithTag("VRCanvas");
        menuManager = FindObjectOfType<VRMenuManager>().gameObject;

        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        // Get a random set of coordinates from the list to spawn user in unique location
        coordinates spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
        SetPlayerSpawn(spawnLocation.longitutde, spawnLocation.latitude, spawnLocation.playerElevation);

        // Fade player in when application first starts
        FadeScreen.Instance.FadeIn();
    }

    private void SetPlayerSpawn(float longitutde, float latitude, float playerElevation)
    {
        SetNewArcGISMapOrigin(longitutde, latitude);

        if (!XROrigin) { XROrigin = FindObjectOfType<XROrigin>().gameObject; }
        XROrigin.transform.position = new Vector3(XROrigin.transform.position.x, playerElevation, XROrigin.transform.position.z);
    }

    private void SetNewArcGISMapOrigin(float longitutde, float latitude)
    {
        if (!arcGISMapComponent)
        {
            arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();
        }
        arcGISMapComponent.OriginPosition = new ArcGISPoint(longitutde, latitude, 0, ArcGISSpatialReference.WGS84());
    }

    // Function to fade screen into static color, load into new area, then fade back out of the color
    IEnumerator LoadIntoNewAreaWithFade(coordinates Location)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }

        menuManager.GetComponent<VRMenuManager>().SetCurrentlyTeleporting(true);

        XROrigin.GetComponent<ActivateGrabRay>().currentlyTransporting = true;

        FadeScreen.Instance.FadeOut();

        // Wait for the fade out to finish before switching locations
        yield return new WaitForSeconds(FadeScreen.Instance.GetFadeDuration());

        SetPlayerSpawn(Location.longitutde, Location.latitude, Location.playerElevation);

        FadeScreen.Instance.FadeIn();

        menuManager.GetComponent<VRMenuManager>().SetCurrentlyTeleporting(false);

        XROrigin.GetComponent<ActivateGrabRay>().currentlyTransporting = false;
    }

    public void GoToRandomLocation()
    {
        coordinates spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
        StartCoroutine(LoadIntoNewAreaWithFade(spawnLocation));
    }

    private void GetLocationByName(string locationName)
    {
        foreach (coordinates location in spawnLocations)
        {
            if (location.name == locationName)
            {
                StartCoroutine(LoadIntoNewAreaWithFade(location));
                return;
            }
        }
    }

    public void GoToSanFran()
    {
        GetLocationByName("San Francisco");
    }

    public void GoToGironaSpain()
    {
        GetLocationByName("Girona, Spain");
    }

    public void GoToChristchurchNewZealand()
    {
        GetLocationByName("Christchurch, New Zealand");
    }

    public void GoToMontrealCanada()
    {
        GetLocationByName("Montreal, Canada");
    }

    public void GoToFiordlandNationalPark()
    {
        GetLocationByName("Fiordland National Park");
    }
    
    public void GoToMtEverest()
    {
        GetLocationByName("Mt Everest");
    }

    public void GoToGrandCanyon()
    {
        GetLocationByName("Grand Canyon");
    }
}
