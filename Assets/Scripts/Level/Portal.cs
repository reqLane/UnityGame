using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string sceneDestination;

    private void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

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

        GameManager.Instance.AudioManager.Play("Portal");

        SceneManager.LoadScene(sceneDestination);
    }
}
