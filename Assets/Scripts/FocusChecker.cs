using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusChecker : MonoBehaviour
{
    [SerializeField]Vector2 focusPosition = Vector2.zero;
    private BoxCollider2D m_boxcolider =null;

    private bool TriggerSet = false;
    void Awake()
    {
        m_boxcolider = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        if(TriggerSet)return;
        var checkPosition = new Vector2(transform.position.x+m_boxcolider.offset.x,transform.position.y+m_boxcolider.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition,m_boxcolider.size,0f,LayerMask.GetMask("Zabi"));
        if(hitInfo)
        {
            GameCore.m_CameraController.SetFocus(new Vector3(focusPosition.x,focusPosition.y,-10f));
        }
    }
}
