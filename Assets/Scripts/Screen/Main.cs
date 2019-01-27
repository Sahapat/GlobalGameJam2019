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
    public static GameController m_gamecontroller;
    public static GameObject Zabi_obj;
    public static AudioController m_audioController;
}
public class Main : MonoBehaviour
{
    [Header("Load Scene Property")]
    [SerializeField] GameObject showOption = null;
    [SerializeField] float delayBeforeLoad = 1f;
    public bool isTargetPC
    {
        get; private set;
    }
    public int deltaTimePass
    {
        get; private set;
    }
    public int currentLevel = 0;
    bool trigger = false;
    private int loadIndex;
    void Awake()
    {
        GameCore.m_CameraController = Camera.main.GetComponent<CameraController>();
        GameCore.m_Main = this;
        GameCore.m_UIHandler = GetComponent<UIHandler>();
        GameCore.m_obtacleController = GetComponent<ObtacleController>();
        GameCore.m_gamecontroller = GetComponent<GameController>();
        GameCore.m_audioController = GetComponent<AudioController>();
        GameCore.Zabi_obj = GameObject.FindGameObjectWithTag("Player");
#if UNITY_IOS || UNITY_ANDROID
        {
            isTargetPC = false;
        }
#else
        {
            isTargetPC = true;
        }
#endif
    }
    void Start()
    {
        GameCore.m_audioController.PlayThemeSound(0);
    }
    void FixedUpdate()
    {
        if (GameCore.m_gamecontroller.isGameStart && (GameCore.m_gamecontroller.isGameOver||GameCore.m_gamecontroller.isGamePass))
        {
            deltaTimePass++;
        }
    }
    public void SendLoadIndex(int index)
    {
        if (trigger) return;
        trigger = true;
        GameCore.m_UIHandler.DoFadeOut();
        loadIndex = index;
        Invoke("LoadScene", delayBeforeLoad);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(loadIndex);
    }
    public void ShowOption()
    {
        showOption.SetActive(true);
    }
    public void CloseOption()
    {
        showOption.SetActive(false);
    }
}
