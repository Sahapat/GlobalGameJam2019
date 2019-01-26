using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingObtacle : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;
    private EdgeCollider2D m_edgeColider2D;

    void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_edgeColider2D = GetComponent<EdgeCollider2D>();
    }
    public virtual void SwitchObtacle()
    {
        m_edgeColider2D.enabled = !m_edgeColider2D.enabled;

        if(m_edgeColider2D.enabled)
        {
            StopAllCoroutines();
            StartCoroutine(FadeIn());
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        while(m_spriteRenderer.color.a < 0.99f)
        {
            m_spriteRenderer.color = Color.Lerp(m_spriteRenderer.color,Color.white,0.15f);
            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        while(m_spriteRenderer.color.a > 0.01f)
        {
            m_spriteRenderer.color = Color.Lerp(m_spriteRenderer.color,new Color(Color.red.r,Color.red.g,Color.red.b,0),0.15f);
            yield return null;
        }
    }
}
