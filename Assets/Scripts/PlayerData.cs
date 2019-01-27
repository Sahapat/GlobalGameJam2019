using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct playerLevelData
{
    public int level;
    public int score;
    public bool isPass;
};
public static class PlayerData
{
    public static List<playerLevelData> levelData;
    public static float volume = 0.5f;
}
