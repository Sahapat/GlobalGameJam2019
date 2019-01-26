using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melvin : MonoBehaviour
{
    [SerializeField] float movingScale = 2f;

    private Rigidbody2D m_rigidbody2D = null;
    private Animator m_animator = null;
    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        if(GameCore.m_gamecontroller.isGameOver || GameCore.m_gamecontroller.isGamePass)
        {
            m_rigidbody2D.simulated = false;
            return;
        }
        DoMoving();
    }
    void DoMoving()
    {
        m_rigidbody2D.velocity = new Vector2(movingScale,m_rigidbody2D.velocity.y);
    }
    public void MoveToZabi()
    {
        StartCoroutine(DeMoveToZabi());
    }
    private IEnumerator DeMoveToZabi()
    {
        m_animator.SetTrigger("Jump");
        while(Vector3.Distance(transform.position,GameCore.Zabi_obj.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position,GameCore.Zabi_obj.transform.position,Time.deltaTime*9.5f);
            yield return null;
        }
        transform.position = GameCore.Zabi_obj.transform.position;
    }
}
