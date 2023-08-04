using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VRMenuManager : MonoBehaviour
{
    private GameObject menu;
    private GameObject esriLogo;
    private Color esriLogoColor;
    [SerializeField] private InputActionProperty toggleMenuButton;
    [SerializeField] private Transform VRhead;
    [SerializeField] private float spawnDistance = 2f;
    [SerializeField] private float logoFadeOutTime = 2f;

    private void Start()
    {
        menu = GameObject.FindWithTag("VRCanvas");
        esriLogo = GameObject.FindWithTag("EsriLogoCanvas");

        if (esriLogo)
        {
            esriLogoColor = esriLogo.transform.GetChild(0).gameObject.GetComponent<Image>().color;
            esriLogo.SetActive(true);
            esriLogo.transform.position = VRhead.position + new Vector3(VRhead.forward.x, 0, VRhead.forward.z).normalized * 2;
            //StartCoroutine(FadeOutLogo());
        }
    }

    private void Update()
    {
        if (menu)
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

    private IEnumerator FadeOutLogo()
    {
        float timer = 0;
        Color newColor;

        // While timer has not concluded, change material alpha using lerp
        while (timer <= logoFadeOutTime)
        {
            newColor = esriLogoColor;
            newColor.a = Mathf.Lerp(1, 0, timer / logoFadeOutTime);
            esriLogoColor = newColor;
            timer += Time.fixedDeltaTime;
            yield return null;
        }

        // Disable the gameobject at the end of the timer
        esriLogo.SetActive(false);
    }
}
