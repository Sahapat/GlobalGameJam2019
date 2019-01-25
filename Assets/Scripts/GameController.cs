using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isGameStart
    {
        get; private set;
    }

    public void GameStart()
    {
        isGameStart =true;
    }
    public void GameOver()
    {
        isGameStart = false;
    }
}
