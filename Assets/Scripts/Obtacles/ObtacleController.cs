using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleController : MonoBehaviour
{
    SwitchingObtacle[] m_switchingObtacles = null;
    Bobby[] m_Bobbys= null;
    
    void Awake()
    {
        m_switchingObtacles = FindObjectsOfType<SwitchingObtacle>();
        m_Bobbys = FindObjectsOfType<Bobby>();
    }
    public void Switching()
    {
        for(int i = 0;i<m_switchingObtacles.Length;i++)
        {
            m_switchingObtacles[i].SwitchObtacle();
        }
        for(int i=0;i<m_Bobbys.Length;i++)
        {
            m_Bobbys[i].SwitchState();
        }
    }
}
