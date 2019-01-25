using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore
{
    public static Main m_Main;
    public static CameraController m_CameraController;
    public static UIHandler m_UIHandler;
    public static ObtacleController m_obtacleController;
}
public class Main : MonoBehaviour
{
    public bool isTargetPC
    {
        get; private set;
    }
    void Awake()
    {
        GameCore.m_CameraController = Camera.main.GetComponent<CameraController>();
        GameCore.m_Main = this;
        GameCore.m_UIHandler = GetComponent<UIHandler>();
        GameCore.m_obtacleController = GetComponent<ObtacleController>();

        #if UNITY_IOS || UNITY_ANDROID
        {
            isTargetPC = false;
        }
        #else
        {
            isTargetPC = true;
            Cursor.visible = false;
        }
        #endif
    }
}
