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
    public void SwitchObtacle()
    {
        m_spriteRenderer.enabled = !m_spriteRenderer.enabled;
        m_edgeColider2D.enabled = !m_edgeColider2D.enabled;
    }
}
