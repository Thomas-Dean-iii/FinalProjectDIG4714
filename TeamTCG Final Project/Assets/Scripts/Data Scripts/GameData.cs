using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{
    public int level;

    public Vector3 playerPostion;

    public GameData() //starting values
    {
        this.level = 0;
        playerPostion = Vector3.zero; //whatever the player's starting position is that's to be detrmined in hopefully a few hours
    }
}
