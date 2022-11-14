using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    //
    private BattleRoom currentRoom;

    public BattleRoom CurrentRoom { get => currentRoom; set => currentRoom = value; }

    public void StartBattle()
    {
        if (currentRoom != null && currentRoom.RoomIsActivated && !currentRoom.RoomIsDone)
        {
            BattleManager.Instance.StartBattle();
        }
    }

    public void EndBattle()
    {
        if (currentRoom != null)
        {
            currentRoom.DeactivateRoom();
            this.currentRoom = null;
        }
    }
}
