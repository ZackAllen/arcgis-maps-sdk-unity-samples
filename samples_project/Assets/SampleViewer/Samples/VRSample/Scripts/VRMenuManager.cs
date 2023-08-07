using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VRMenuManager : MonoBehaviour
{
    private GameObject menu;
    private GameObject esriLogo;
    [SerializeField] private InputActionProperty toggleMenuButton;
    [SerializeField] private Transform VRhead;
    [SerializeField] private float spawnDistance = 2f;

    private bool currentlyTeleporting = false;

    private void Start()
    {
        menu = GameObject.FindWithTag("VRCanvas");
        esriLogo = GameObject.FindWithTag("EsriLogoCanvas");

        Invoke("InsertLogo", 0.1f);
    }

    private void Update()
    {
        if (menu)
        {
            if (toggleMenuButton.action.WasPressedThisFrame() && !currentlyTeleporting)
            {
                menu.SetActive(!menu.activeSelf);

                menu.transform.position = VRhead.position + new Vector3(VRhead.forward.x, 0, VRhead.forward.z).normalized * spawnDistance;
            }

            menu.transform.LookAt(new Vector3(VRhead.position.x, menu.transform.position.y, VRhead.position.z));
            menu.transform.forward *= -1;
        }

    }

    private void InsertLogo()
    {
        if (esriLogo)
        {
            esriLogo.SetActive(true);
            esriLogo.transform.position = VRhead.position + new Vector3(VRhead.forward.x, 0, VRhead.forward.z).normalized * 2;
        }
    }

    public void SetCurrentlyTeleporting(bool isCurrentlyTeleporting)
    {
        currentlyTeleporting = isCurrentlyTeleporting;
    }
}
