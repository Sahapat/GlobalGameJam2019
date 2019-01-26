using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobby : MonoBehaviour
{
    [SerializeField] Vector2 firstPosition = Vector2.zero;
    [SerializeField] Vector2 secondPosition = Vector2.zero;
    [SerializeField] float movingSpeed = 3f;
    [SerializeField] bool moveDirection = false;

    private BoxCollider2D m_boxColider2d = null;

    void Awake()
    {
        m_boxColider2d = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        PlayerChecker();
        if (GameCore.m_gamecontroller.isGameOver) return;
        MovingBobby();
    }
    void PlayerChecker()
    {
        var checkPosition = new Vector2(transform.position.x + m_boxColider2d.offset.x, transform.position.y + m_boxColider2d.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition, m_boxColider2d.size, 0f, LayerMask.GetMask("Zabi"));

        if (hitInfo)
        {
            GameCore.m_gamecontroller.GameOver();
        }
    }
    void MovingBobby()
    {
        if (moveDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, firstPosition, Time.deltaTime * movingSpeed);
            if (transform.position.x == firstPosition.x && transform.position.y == firstPosition.y)
            {
                moveDirection = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, secondPosition, Time.deltaTime * movingSpeed);
            if (transform.position.x == secondPosition.x && transform.position.y == secondPosition.y)
            {
                moveDirection = true;
            }
        }
    }
}
