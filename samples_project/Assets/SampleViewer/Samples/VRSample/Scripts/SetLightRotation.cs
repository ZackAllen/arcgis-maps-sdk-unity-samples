using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightRotation : MonoBehaviour
{
    private GameObject directionalLight;

    private void Start()
    {
        directionalLight = GameObject.Find("Directional Light");
    }

    public void SetDirectionalLightRotation(float value)
    {
        Debug.Log("value: " + value);
        if (directionalLight)
        {
            Debug.Log("directionalLight.transform.rotation.eulerAngles.y: " + directionalLight.transform.rotation.eulerAngles.y);
            directionalLight.transform.rotation = Quaternion.Euler(value, directionalLight.transform.rotation.eulerAngles.y, directionalLight.transform.rotation.eulerAngles.z);
        }
    }
}
