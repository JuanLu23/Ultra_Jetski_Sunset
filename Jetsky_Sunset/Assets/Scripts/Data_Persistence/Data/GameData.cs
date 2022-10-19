using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector2 v2_fastestTime;

    public GameData()
    {
        this.v2_fastestTime = Vector2.zero;
    }
}
