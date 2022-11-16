using Project.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private BattleRoom currentRoom;

    public BattleRoom CurrentRoom { get => currentRoom; set => currentRoom = value; }

    public void StartBattle()
    {
        if (currentRoom != null && currentRoom.RoomIsActivated && !currentRoom.RoomIsDone)
        {
            GameManager.Instance.BattleManager.StartBattle();
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
