using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melvin : MonoBehaviour
{
    [SerializeField] float movingScale = 2f;

    private Rigidbody2D m_rigidbody2D = null;
    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        DoMoving();
    }
    void DoMoving()
    {
        m_rigidbody2D.velocity = new Vector2(movingScale,m_rigidbody2D.velocity.y);
    }

}
