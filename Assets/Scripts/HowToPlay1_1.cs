using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay1_1 : MonoBehaviour
{
    void Update()
    {
        if(GameCore.m_gamecontroller.isGameStart)
        {
            Destroy(this.gameObject);
        }
    }
}
