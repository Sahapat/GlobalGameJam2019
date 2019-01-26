using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{

    [SerializeField] Image fadeImage = null;
    void Awake()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        fadeImage.color = new Color(0,0,0,1);
        while(fadeImage.color.a > 0.01f)
        {
            fadeImage.color = Color.Lerp(fadeImage.color,new Color(0,0,0,0),0.1f);
            yield return null;
        }
        fadeImage.color = new Color(0,0,0,0);
    }
    private IEnumerator FadeOut()
    {
        fadeImage.color = new Color(0,0,0,0);
        while(fadeImage.color.a < 0.99f)
        {
            fadeImage.color = Color.Lerp(fadeImage.color,new Color(0,0,0,1),0.1f);
            yield return null;
        }
        fadeImage.color = new Color(0,0,0,1);
    }
    public void DoFadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }
    public void DoFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }
}
