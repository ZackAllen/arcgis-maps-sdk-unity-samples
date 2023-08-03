using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private InputActionProperty toggleMenuButton;
    [SerializeField] private Transform VRhead;
    [SerializeField] private float spawnDistance =2f;

    private void Update()
    {
        if (toggleMenuButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = VRhead.position + new Vector3(VRhead.forward.x, 0, VRhead.forward.z).normalized * spawnDistance;
        }

        menu.transform.LookAt(new Vector3(VRhead.position.x, menu.transform.position.y, VRhead.position.z));
        menu.transform.forward *= -1;
    }
}
