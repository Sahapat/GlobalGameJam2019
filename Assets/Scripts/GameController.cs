﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject melvinPrefab = null;
    [SerializeField] Transform melvinSpawnPoint = null;
    [SerializeField] GameObject PassChecker = null;
    [SerializeField] Transform passDestination = null;
    [SerializeField] float relativeTimeToPass = 0.2f;
    private BoxCollider2D passColiderRef = null;

    private bool passTrigger = false;
    private bool overTrigger = false;

    private Melvin m_melvin = null;
    void Awake()
    {
        passColiderRef = PassChecker.GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        var checkPosition = new Vector2(PassChecker.transform.position.x + passColiderRef.offset.x, PassChecker.transform.position.y + passColiderRef.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition, passColiderRef.size, 0f, LayerMask.GetMask("Zabi"));

        if (hitInfo)
        {
            GamePass();
        }
    }
    public bool isGameStart
    {
        get; private set;
    }
    public bool isGameOver
    {
        get; private set;
    }
    public bool isGamePass
    {
        get; private set;
    }

    public void GameStart()
    {
        isGameStart = true;
        m_melvin = Instantiate(melvinPrefab, melvinSpawnPoint.position, Quaternion.identity).GetComponent<Melvin>();
    }
    public void GameOver(byte overValue)
    {
        isGameOver = true;
        switch (overValue)
        {
            case 0:
                if (!overTrigger)
                {
                    overTrigger =true;
                    var levelToSave = "Level" + GameCore.m_Main.currentLevel;
                    PlayerPrefs.SetInt(levelToSave, GameCore.m_Main.deltaTimePass * 3);
                    PlayerPrefs.SetInt(levelToSave+"Pass",0);
                    GameCore.m_audioController.PlayOtherSound(0);
                    GameCore.m_audioController.PlayThemeSound(1);
                    Invoke("PlayExtraLose",0.3f);
                    GameCore.m_UIHandler.ShowLose();
                    m_melvin.MoveToZabi();
                }
                break;
            case 1:
                if (!overTrigger)
                {
                    overTrigger =true;
                    var levelToSave = "Level" + GameCore.m_Main.currentLevel;
                    PlayerPrefs.SetInt(levelToSave, GameCore.m_Main.deltaTimePass * 3);
                    PlayerPrefs.SetInt(levelToSave+"Pass",0);
                    GameCore.m_audioController.PlayOtherSound(0);
                    GameCore.m_audioController.PlayThemeSound(1);
                    Invoke("PlayExtraLose",0.3f);
                    GameCore.m_UIHandler.ShowLose();
                }
            break;
        }
    }
    public void GamePass()
    {
        isGamePass = true;
        if (!passTrigger)
        {
            var levelToSave = "Level" + GameCore.m_Main.currentLevel;
            PlayerPrefs.SetInt(levelToSave, GameCore.m_Main.deltaTimePass * 3);
            PlayerPrefs.SetInt(levelToSave+"Pass",1);
            GameCore.m_audioController.PlayThemeSound(1);
            GameCore.m_audioController.PlayOtherSound(1);
            GameCore.m_UIHandler.ShowPass();
            StartCoroutine(DoPass(GameCore.Zabi_obj, passDestination.position));
            passTrigger = true;
        }
    }
    private IEnumerator DoPass(GameObject targetObject, Vector3 destination)
    {
        targetObject.GetComponent<Rigidbody2D>().simulated = false;
        while (Vector3.Distance(targetObject.transform.position, destination) != 0)
        {
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, destination, relativeTimeToPass);
            targetObject.transform.localScale = Vector3.MoveTowards(targetObject.transform.localScale, Vector3.zero, Time.deltaTime);
            yield return null;
        }
    }
    private void PlayExtraLose()
    {
        GameCore.m_audioController.PlayExtraSound(2);
    }
}
