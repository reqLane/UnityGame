using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Record 
{
    public int level;
    public float time;

    public override string ToString()
    {
        int minutes = (int)Mathf.Floor(time) / 60;
        int seconds = (int)Mathf.Floor(time) % 60;
        return minutes + ":" + seconds;
    }
}
