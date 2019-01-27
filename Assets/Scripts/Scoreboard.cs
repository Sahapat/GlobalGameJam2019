using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoreboard : MonoBehaviour
{
    [SerializeField] Text scoreTxt = null;
    [SerializeField] float speed = 5f;
    private int real_score = 0;
    private int currentScore = 0;

    bool isStop = false;
    void FixedUpdate()
    {
        scoreTxt.text = currentScore.ToString();
        if(isStop)return;
        if(currentScore > real_score)
        {
            currentScore = real_score;
            isStop = true;
        }
        currentScore += (int)(speed);
    }
    void OnEnable()
    {
        real_score = GameCore.m_Main.deltaTimePass*3;
    }
}
