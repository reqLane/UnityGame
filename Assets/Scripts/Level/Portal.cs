using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneDestination;

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
        }
        GameManager.Instance.UiManager.ShowHint("");
        SceneManager.LoadScene(sceneDestination);

        yield break;
    }
}
