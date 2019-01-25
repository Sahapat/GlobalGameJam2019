using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Vector2 runVelocity = Vector2.zero;

    bool isFirstInput = false;
    bool isSecondInput = false;

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        #region TestInput
        GameCore.m_UIHandler.UpdateTouch1Status(isFirstInput.ToString());
        GameCore.m_UIHandler.UpdateTouch2Status(isSecondInput.ToString());
        #endregion

        if(isFirstInput)
        {
            MovingCharacter();
        }

        if(isSecondInput)
        {
            SpecialAction();
        }
    }
    void GetInput()
    {
        isFirstInput = false;
        isSecondInput = false;
        if(GameCore.m_Main.isTargetPC)
        {
            if(Input.GetMouseButton(0))
            {
                isFirstInput = true;
            }

            if(Input.GetMouseButtonDown(1))
            {
                isSecondInput = true;
            }
        }
        else
        {
            var touches = Input.touches;
            if(touches.Length > 0)
            {
                isFirstInput = true;

                if(touches.Length > 1 && touches[1].phase == TouchPhase.Began)
                {
                    isSecondInput = true;
                }
            }
            
        }

        #if UNITY_EDITOR
        {
            if(Input.GetMouseButton(0))
            {
                isFirstInput = true;
            }

            if(Input.GetMouseButtonDown(1))
            {
                isSecondInput = true;
            }
        }
        #endif
    }
    void MovingCharacter()
    {
        
    }
    void SpecialAction()
    {

    }
}
