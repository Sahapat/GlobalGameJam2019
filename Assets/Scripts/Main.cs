using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameCore
{
    public static Main m_Main;
    public static CameraController m_CameraController;
    public static UIHandler m_UIHandler;
    public static ObtacleController m_obtacleController;
}
public class Main : MonoBehaviour
{
    [Header("Load Scene Property")]
    [SerializeField]float delayBeforeLoad = 1f;
    public bool isTargetPC
    {
        get; private set;
    }

    private int loadIndex;
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
    public void SendLoadIndex(int index)
    {
        GameCore.m_UIHandler.DoFadeOut();
        loadIndex = index;
        Invoke("LoadScene",delayBeforeLoad);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(loadIndex);
    }
}
