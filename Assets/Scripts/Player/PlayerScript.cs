﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float runVelocity = 5f;

    bool isFirstInput = false;
    bool isSecondInput = false;

    private Rigidbody2D m_rigidbody2D = null;
    private PlayerPhysicshandler m_playerPhysicshanlder = null;
    private Animator m_animator = null;
    SpriteMask temp;
    void Awake()
    {
        m_playerPhysicshanlder = GetComponent<PlayerPhysicshandler>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {        
        if(GameCore.m_gamecontroller.isGameOver)
        {
            GameOver();
            return;
        }
        else if(GameCore.m_gamecontroller.isGamePass)
        {
            GamePass();
            return;
        }
        GetInput();
        AnimationStateController();
    }

    void FixedUpdate()
    {
        #region TestInput
        GameCore.m_UIHandler.UpdateTouch1Status(isFirstInput.ToString());
        GameCore.m_UIHandler.UpdateTouch2Status(isSecondInput.ToString());
        #endregion
        if (isFirstInput)
        {
            MovingCharacter();
        }

        if (isSecondInput)
        {
            SpecialAction();
        }
    }
    void GetInput()
    {
        isFirstInput = false;
        isSecondInput = false;
        if (GameCore.m_Main.isTargetPC)
        {
            if (Input.GetMouseButton(0))
            {
                isFirstInput = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                isSecondInput = true;
            }
        }
        else
        {
            var touches = Input.touches;
            if (touches.Length > 0)
            {
                isFirstInput = true;

                if (touches.Length > 1 && touches[1].phase == TouchPhase.Began)
                {
                    isSecondInput = true;
                }
            }

        }

#if UNITY_EDITOR
        {
            if (Input.GetMouseButton(0))
            {
                isFirstInput = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                isSecondInput = true;
            }
        }
#endif
    }
    void MovingCharacter()
    {
        if(!m_playerPhysicshanlder.isTocuhingFloor)return;
        m_rigidbody2D.velocity = new Vector2(runVelocity, m_rigidbody2D.velocity.y);
    }
    void SpecialAction()
    {
        GameCore.m_obtacleController.Switching();
    }
    void AnimationStateController()
    {
        m_animator.SetBool("TouchingFloor",m_playerPhysicshanlder.isTocuhingFloor);
        m_animator.SetBool("Walking",isFirstInput);
    }
    void GameOver()
    {
        m_animator.SetBool("TouchingFloor",false);
        m_animator.SetBool("Walking",false);
        isFirstInput = false;
        isSecondInput = false;
        this.enabled = false;
    }
    void GamePass()
    {
        m_animator.SetBool("TouchingFloor",false);
        m_animator.SetBool("Walking",false);
        m_animator.SetTrigger("Swim");
        isFirstInput = false;
        isSecondInput = false;
        this.enabled = false;
    }
}