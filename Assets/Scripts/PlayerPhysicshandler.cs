using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicshandler : MonoBehaviour
{
    [SerializeField]Vector2 onFallGravity = new Vector2(0,-9.81f);
    [SerializeField]Vector2 onGroundGravity = new Vector2(4.5f,-9.81f);
    [SerializeField]float onfallDrag = 0f;
    [SerializeField]float onGroundDrag = 5f;
    private BoxCollider2D m_colider2D = null;
    private Rigidbody2D m_rigidbody2D = null;

    public bool isTocuhingFloor
    {
        get; private set;
    }

    void Awake()
    {
        m_colider2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var checkPosition = new Vector2(transform.position.x + m_colider2D.offset.x,transform.position.y+m_colider2D.offset.y);
        var hit = Physics2D.OverlapBox(checkPosition,m_colider2D.size,0f,LayerMask.GetMask("Floor"));
        if(hit)
        {
            Physics2D.gravity = onGroundGravity;
            m_rigidbody2D.drag = onGroundDrag;
            isTocuhingFloor = true;
        }
        else
        {
            Physics2D.gravity = onFallGravity;
            m_rigidbody2D.drag = onfallDrag;
            isTocuhingFloor = false;
        }
    }
}
