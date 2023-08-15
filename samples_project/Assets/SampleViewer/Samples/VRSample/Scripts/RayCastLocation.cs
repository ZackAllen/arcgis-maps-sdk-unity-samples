using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class RayCastLocation : MonoBehaviour
{
    [SerializeField] private InputActionProperty raycastInput;
    [SerializeField] private Geocoder geocoder;

    void Start()
    {
        
    }

    private void Update()
    {
        if (raycastInput.action.WasPressedThisFrame())
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit))
            {
                float offsetDistance = hit.distance;
                Debug.Log(offsetDistance);
                Debug.Log(geocoder.HitToGeoPosition(hit));
                geocoder.ReverseGeocode(geocoder.HitToGeoPosition(hit));
            }
        }
    }
}
