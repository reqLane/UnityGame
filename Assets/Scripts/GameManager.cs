using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Player player;

    public Player Player { get => player; set => player = value; }
}
