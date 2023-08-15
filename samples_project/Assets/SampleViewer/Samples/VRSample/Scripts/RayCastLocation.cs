using Esri.ArcGISMapsSDK.Components;
using Esri.ArcGISMapsSDK.Utils.GeoCoord;
using Esri.GameEngine.Geometry;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Esri.HPFramework;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class RayCastLocation : MonoBehaviour
{
    [SerializeField] private InputActionProperty raycastInput;

    private ArcGISMapComponent arcGISMapComponent;
    private string responseAddress = "";
    private readonly string LocationQueryURL = "https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/reverseGeocode";

    void Start()
    {
        arcGISMapComponent = FindObjectOfType<ArcGISMapComponent>();
    }

    private void Update()
    {
        if (raycastInput.action.WasPressedThisFrame())
        {
            GetAddress();
        }
    }

    private async void GetAddress()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            await ReverseGeocode(HitToGeoPosition(hit));
            Debug.Log(responseAddress);
        }
    }

    /// <summary>
    /// Return GeoPosition for an engine location hit by a raycast.
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    public ArcGISPoint HitToGeoPosition(RaycastHit hit, float yOffset = 0)
    {
        var worldPosition = math.inverse(arcGISMapComponent.WorldMatrix).HomogeneousTransformPoint(hit.point.ToDouble3());
        var geoPosition = arcGISMapComponent.View.WorldToGeographic(worldPosition);
        var offsetPosition = new ArcGISPoint(geoPosition.X, geoPosition.Y, geoPosition.Z + yOffset, geoPosition.SpatialReference);

        return GeoUtils.ProjectToSpatialReference(offsetPosition, new ArcGISSpatialReference(4326));
    }

    /// <summary>
    /// Perform a reverse geocoding query (location lookup) and parse the response. If the server returned an error, the message is shown to the user.
    /// The function is called when a location on the map is selected.
    /// </summary>
    /// <param name="location"></param>
    public async Task ReverseGeocode(ArcGISPoint location)
    {
        string results = await SendLocationQuery(location.X.ToString() + "," + location.Y.ToString());

        if (results.Contains("error")) // Server returned an error
        {
            var response = JObject.Parse(results);
            var error = response.SelectToken("error");
            Debug.Log((string)error.SelectToken("message"));
        }
        else
        {
            var response = JObject.Parse(results);
            var address = response.SelectToken("address");
            var label = address.SelectToken("LongLabel");
            responseAddress = (string)label;

            if (string.IsNullOrEmpty(responseAddress))
            {
                Debug.Log("Query did not return a valid response.");
            }
        }
    }

    /// <summary>
    ///  Create and send an HTTP request for a reverse geocoding query and return the received response.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    private async Task<string> SendLocationQuery(string location)
    {
        IEnumerable<KeyValuePair<string, string>> payload = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("location", location),
            new KeyValuePair<string, string>("langCode", "en"),
            new KeyValuePair<string, string>("f", "json"),
        };

        HttpClient client = new HttpClient();
        HttpContent content = new FormUrlEncodedContent(payload);
        HttpResponseMessage response = await client.PostAsync(LocationQueryURL, content);

        response.EnsureSuccessStatusCode();
        string results = await response.Content.ReadAsStringAsync();
        return results;
    }
}
