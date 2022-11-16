using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D doorCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorCollider.enabled = false;
        animator = GetComponent<Animator>();
    }

    public void openDoor()
    {
        doorCollider.enabled = false;
        animator.Play("door_up");
    }

    public void closeDoor()
    {
        doorCollider.enabled = true;
        animator.Play("door_down");
    }
}
