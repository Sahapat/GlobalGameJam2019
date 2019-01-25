using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicshandler : MonoBehaviour
{
    [SerializeField]Vector2 onFallGravity = new Vector2(0,-9.81f);
    [SerializeField]Vector2 onGroundGravity = new Vector2(4.5f,-9.81f);
    [SerializeField]float onfallDrag = 0f;
    [SerializeField]float onGroundDrag = 5f;
    private BoxCollider2D m_boxcolider2D = null;
    private Rigidbody2D m_rigidbody2D = null;

    void Awake()
    {
        m_boxcolider2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var hit = Physics2D.OverlapBox(new Vector2(transform.position.x+m_boxcolider2D.offset.x,transform.position.y+m_boxcolider2D.offset.y),m_boxcolider2D.size,0f,LayerMask.GetMask("Floor"));
        if(hit)
        {
            Physics2D.gravity = onGroundGravity;
            m_rigidbody2D.drag = onGroundDrag;

        }
        else
        {
            Physics2D.gravity = onFallGravity;
            m_rigidbody2D.drag = onfallDrag;
        }
    }
}
