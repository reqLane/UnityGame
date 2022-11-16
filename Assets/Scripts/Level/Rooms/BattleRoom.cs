using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : MonoBehaviour
{
    private bool roomIsActivated;
    private bool roomIsDone;

    [SerializeField]
    private Wave[] waves;

    [SerializeField]
    private Door[] doors;

    public Wave[] Waves { get => waves; set => waves = value; }
    public bool RoomIsActivated { get => roomIsActivated; set => roomIsActivated = value; }
    public bool RoomIsDone { get => roomIsDone; set => roomIsDone = value; }

    void Start()
    {
        roomIsActivated = false;
        roomIsDone = false;
    } 

    public void OpenAllDoors()
    {
        foreach (Door door in doors)
        {
            door.openDoor();
        }
    }

    public void CloseAllDoors()
    {
        foreach (Door door in doors)
        {
            door.closeDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player" && !roomIsActivated && !roomIsDone)
        {
            StartCoroutine(ActivateRoom());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && roomIsActivated)
        {
            roomIsActivated = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator ActivateRoom()
    {
        roomIsActivated = true;

        yield return new WaitForSeconds(0.5f);

        CloseAllDoors();

        GameManager.Instance.LevelManager.CurrentRoom = this;
        GameManager.Instance.LevelManager.StartBattle();
        
        yield break;
    }

    public void DeactivateRoom()
    {
        roomIsActivated = false;
        roomIsDone = true;
        OpenAllDoors();
    }

}
