using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtacleController : MonoBehaviour
{
    [SerializeField] SwitchingObtacle[] m_switchingObtacles = null;

    public void Switching()
    {
        for(int i = 0;i<m_switchingObtacles.Length;i++)
        {
            m_switchingObtacles[i].SwitchObtacle();
        }
    }
}
