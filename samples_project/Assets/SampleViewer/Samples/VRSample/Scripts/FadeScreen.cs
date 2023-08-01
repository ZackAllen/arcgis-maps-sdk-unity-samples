using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    
    [SerializeField] private float fadeDuration = 2;
    [SerializeField] private Color fadeColor;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    private IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        Color newColor;

        while (timer <= fadeDuration)
        {
            newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            renderer.material.SetColor("_UnlitColor", newColor);
            timer += Time.fixedDeltaTime;
            yield return null;
        }

        Color lastColor = fadeColor;
        lastColor.a = alphaOut;
        renderer.material.SetColor("_UnlitColor", lastColor);
    }
}
