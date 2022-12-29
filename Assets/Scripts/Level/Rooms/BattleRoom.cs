using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoom : MonoBehaviour
{
    private bool roomIsActivated;
    private bool roomIsDone;
    private bool wavesStarted;

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
        GameManager.Instance.AudioManager.Play("DoorSound");
    }

    public void CloseAllDoors()
    {
        foreach (Door door in doors)
        {
            door.closeDoor();
        }
        GameManager.Instance.AudioManager.Play("DoorSound");
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
        if (collision.tag == "Player" && roomIsActivated && !wavesStarted)
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
        wavesStarted = true;

        GameManager.Instance.LevelManager.CurrentRoom = this;
        GameManager.Instance.LevelManager.StartBattle();
        GameManager.Instance.AudioManager.SetVolume("Theme", .05f);
        GameManager.Instance.AudioManager.Play("Fighting");
        
        yield break;
    }

    public void DeactivateRoom()
    {
        roomIsActivated = false;
        roomIsDone = true;
        OpenAllDoors();

        GameManager.Instance.AudioManager.Stop("Fighting");
        GameManager.Instance.AudioManager.SetVolume("Theme", .2f);
    }

}
