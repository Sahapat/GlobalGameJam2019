using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroMenu : MonoBehaviour
{
    [SerializeField] Image fadeImage = null;
    [SerializeField] int loadIndex = 0;
    [SerializeField] float delayBeforeLoad = 0.8f;
    bool trigger = false;
    void Awake()
    {
        StartCoroutine(FadeIn());
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!trigger)
        {
            trigger =true;
            Invoke("LoadScene",delayBeforeLoad);
            DoFadeOut();
        }
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
    void LoadScene()
    {
        SceneManager.LoadScene(loadIndex);
    }
}
