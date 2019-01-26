using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobby : MovingObtacle
{
    private BoxCollider2D m_boxColider2d = null;
    void Awake()
    {
        m_boxColider2d = GetComponent<BoxCollider2D>();
    }
    void PlayerChecker()
    {
        var checkPosition = new Vector2(transform.position.x + m_boxColider2d.offset.x, transform.position.y + m_boxColider2d.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition, m_boxColider2d.size, 0f, LayerMask.GetMask("Zabi"));

        if (hitInfo)
        {
            GameCore.m_gamecontroller.GameOver(1);
        }
    }
    protected override void OnFixedUpdate()
    {
        PlayerChecker();
    }
    protected override void OnStopMoving()
    {
        isStopMoving = false;
    }
}
