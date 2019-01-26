using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 firstPosition = Vector2.zero;
    [SerializeField] Vector2 secondPosition = Vector2.zero;
    [SerializeField] float movingSpeed = 3f;
    [SerializeField] bool moveDirection = false;
    [SerializeField] bool isStopMoving = false;
    private BoxCollider2D m_coliderChecker = null;
    private bool canOnPlatform = false;
    void Awake()
    {
        m_coliderChecker = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        if(GameCore.m_gamecontroller.isGameOver)return;
        var checkPosition = new Vector2(transform.position.x+m_coliderChecker.offset.x,transform.position.y+m_coliderChecker.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition,m_coliderChecker.size,0f,LayerMask.GetMask("Zabi"));

        if(hitInfo)
        {
            canOnPlatform = true;
        }
        else
        {
            canOnPlatform = false;
        }
        if(isStopMoving)return;
        DoMoving();
    }
    public void SwitchActive()
    {
        if(canOnPlatform)
        {
            GameCore.Zabi_obj.GetComponent<PlayerScript>().SetSwitchPlatform(this.transform);
            isStopMoving = !isStopMoving;
            moveDirection = !moveDirection;
        }
        else
        {
            isStopMoving = !isStopMoving;
            moveDirection = !moveDirection;
        }
    }
    void DoMoving()
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
