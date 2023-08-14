using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class RayCastLocation : MonoBehaviour
{
    [SerializeField] private InputActionProperty raycastInput;

    void Start()
    {
        
    }

    private void Update()
    {
        if (raycastInput.action.WasPressedThisFrame())
        {
            Debug.Log("test");
        }
    }
}
