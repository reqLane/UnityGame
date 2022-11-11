using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpened;
    private Collider2D doorCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = true;
        doorCollider = GetComponent<Collider2D>();
        doorCollider.enabled = false;
        animator = GetComponent<Animator>();
    }

    public void openDoor()
    {
        isOpened = true;
        doorCollider.enabled = false;
        animator.Play("door_up");
    }

    public void closeDoor()
    {
        isOpened = false;
        doorCollider.enabled = true;
        animator.Play("door_down");
    }
}
