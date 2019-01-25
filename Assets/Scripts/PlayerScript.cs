using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Vector2 runVelocity = Vector2.zero;

    bool isFirstInput = false;
    bool isSecondInput = false;
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

            if(Input.GetMouseButton(1))
            {
                isSecondInput = true;
            }
        }
        else
        {
            var touches = Input.touches;
            if(touches.Length > 0)
            {
            }
            
        }
    }
}
