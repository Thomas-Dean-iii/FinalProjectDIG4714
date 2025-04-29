using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int level;

    public int playersUnlocked; // number of players unlocked



    public GameData() //starting values
    {
        this.level = 0;
        this.playersUnlocked = 0;
    }
}
