using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelData
{
    public static readonly int MaxLevel = 10;
    public static int LevelIndex;

    public static void ChangeLevel(int levelIndex)
    {
        LevelData.LevelIndex = levelIndex;
    }
}
