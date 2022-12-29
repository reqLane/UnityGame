using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneDestination;
    [SerializeField]
    private int level;

    private bool canTeleport;

    private void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);

        if(canTeleport && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(startTeleportation());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.UiManager.ShowHint("Teleport (F)");
            canTeleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.UiManager.ShowHint("");
            canTeleport = false;
        }
    }

    private IEnumerator startTeleportation()
    {
        GameManager.Instance.AudioManager.Play("Portal");

        if(sceneDestination == "GameHub")
        {
            GameManager.Instance.Player.StatsSO.HP = GameManager.Instance.Player.StatsSO.MaxHp;
            if(GameManager.Instance.RecordsManager.CurrentLevel != -1 
                && (GameManager.Instance.RecordsManager.RecordsCollection.records.Length < GameManager.Instance.RecordsManager.CurrentLevel
                || Time.time - GameManager.Instance.RecordsManager.StartTime < GameManager.Instance.RecordsManager.RecordsCollection.records[GameManager.Instance.RecordsManager.CurrentLevel - 1].time))
            {
                GameManager.Instance.RecordsManager.SaveRecord(GameManager.Instance.RecordsManager.CurrentLevel, Time.time - GameManager.Instance.RecordsManager.StartTime);
            }
            GameManager.Instance.RecordsManager.CurrentLevel = -1;
        }

        if(level != -1)
        {
            GameManager.Instance.RecordsManager.CurrentLevel = level;
            GameManager.Instance.RecordsManager.StartTime = Time.time;
        }
        GameManager.Instance.UiManager.ShowHint("");
        SceneManager.LoadScene(sceneDestination);

        yield break;
    }
}
