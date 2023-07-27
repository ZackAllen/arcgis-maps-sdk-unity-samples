using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    [SerializeField] private GameObject rightGrabRay;
    [SerializeField] private GameObject leftGrabRay;

    [SerializeField] private XRDirectInteractor leftDirectGrab;
    [SerializeField] private XRDirectInteractor rightDirectGrab;

    void Update()
    {
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
    }
}
