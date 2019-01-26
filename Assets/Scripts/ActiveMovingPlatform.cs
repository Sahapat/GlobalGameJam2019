using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMovingPlatform : MonoBehaviour
{
    private BoxCollider2D m_boxColider = null;
    void Awake()
    {
        m_boxColider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        var checkPosition = new Vector2(transform.position.x+m_boxColider.offset.x,transform.position.y+m_boxColider.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition,m_boxColider.size,0f,LayerMask.GetMask("Zabi"));

        if(hitInfo)
        {
            GameCore.m_obtacleController.SetControlableMovingPlatform();
        }
    }
}
