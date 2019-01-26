using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObtacle : SwitchingObtacle
{
    [SerializeField] Vector2 firstPosition = Vector2.zero;
    [SerializeField] Vector2 secondPosition = Vector2.zero;
    [SerializeField] float movingSpeed = 3f;
    [SerializeField] bool moveDirection = false;
    protected bool isStopMoving = false;

    void FixedUpdate()
    {
        OnFixedUpdate();
        if (GameCore.m_gamecontroller.isGameOver) return;
        if (isStopMoving)return;
        MovingObject();
    }
    void MovingObject()
    {
        if (moveDirection)
        {
            transform.position = Vector2.MoveTowards(transform.position, firstPosition, Time.deltaTime * movingSpeed);
            if (transform.position.x == firstPosition.x && transform.position.y == firstPosition.y)
            {
                moveDirection = false;
                OnStopMoving();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, secondPosition, Time.deltaTime * movingSpeed);
            if (transform.position.x == secondPosition.x && transform.position.y == secondPosition.y)
            {
                moveDirection = true;
                OnStopMoving();
            }
        }
    }
    public override void SwitchObtacle()
    {
        isStopMoving = !isStopMoving;
        moveDirection = !moveDirection;
    }
    protected virtual void OnFixedUpdate()
    {
        return;
    }
    protected virtual void OnStopMoving()
    {
        return;
    }
}
