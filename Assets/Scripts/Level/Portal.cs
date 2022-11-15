using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneDestination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(startTeleportation());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator startTeleportation()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneDestination);
    }
}
