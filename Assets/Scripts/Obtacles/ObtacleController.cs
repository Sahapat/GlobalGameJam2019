using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleController : MonoBehaviour
{
    SwitchingObtacle[] m_switchingObtacles = null;
    MovingPlatform[] m_movingPlatform = null;

    bool canControlMovingPlatform = false;
    void Awake()
    {
        m_switchingObtacles = FindObjectsOfType<SwitchingObtacle>();
        m_movingPlatform = FindObjectsOfType<MovingPlatform>();
    }
    public void Switching()
    {
        for (int i = 0; i < m_switchingObtacles.Length; i++)
        {
            m_switchingObtacles[i].SwitchObtacle();
        }
        if (canControlMovingPlatform)
        {
            for (int i = 0; i < m_movingPlatform.Length; i++)
            {
                m_movingPlatform[i].SwitchActive();
            }
        }
    }
    public void SetControlableMovingPlatform()
    {
        canControlMovingPlatform = true;
    }
}
