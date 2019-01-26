using System.Collections;
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
    private bool isOnPlatform = false;
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
                if(!GameCore.m_gamecontroller.isGameStart)
                {
                    GameCore.m_gamecontroller.GameStart();
                }
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
                if(touches[0].phase == TouchPhase.Began && !GameCore.m_gamecontroller.isGameStart)
                {
                    GameCore.m_gamecontroller.GameStart();
                }
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
                if(!GameCore.m_gamecontroller.isGameStart)
                {
                    GameCore.m_gamecontroller.GameStart();
                }
                isFirstInput = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                isSecondInput = true;
            }
        }
#endif
            if(GameCore.m_gamecontroller.isGameStart && !isFirstInput && !isSecondInput)
            {
                GameCore.m_gamecontroller.GameOver(0);
            }
    }
    void MovingCharacter()
    {
        if(!m_playerPhysicshanlder.isTocuhingFloor)return;
        if(isOnPlatform)return;
        var assignRun = (m_playerPhysicshanlder.isOnSlope)?runVelocity*1.8f:runVelocity;
        m_rigidbody2D.velocity = new Vector2(assignRun, m_rigidbody2D.velocity.y);
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
    public void SetSwitchPlatform(Transform t_in)
    {
        if(isOnPlatform)
        {
            this.transform.parent = null;
            isOnPlatform = false;
        }
        else
        {
            transform.parent = t_in.transform;
            isOnPlatform =true;
        }
    }
}
