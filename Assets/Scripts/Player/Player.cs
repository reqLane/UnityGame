using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private PlayerStatsSO statsSO;

    private float moveInput;

    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;

    private bool isInvincible;

    private bool isGrounded;
    [SerializeField]
    private Transform feetPos;
    [SerializeField] 
    private float checkRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private Animator animator;
    [SerializeField]
    public GameObject weapon;
    public bool canChangeWeapon;

    public PlayerStatsSO StatsSO { get => statsSO; set => statsSO = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        GameManager.Instance.Player = this;
        canChangeWeapon = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * StatsSO.Speed, rb.velocity.y);
    }

    private void Update()
    {
        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * StatsSO.JumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * StatsSO.JumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if(isGrounded)
        {
            if (Mathf.Abs(rb.velocity.x) < 0.1f && Mathf.Abs(rb.velocity.y) < 0.1f)
            {
                idleAnimation();
            }
            else if(!isJumping)
            {
                walkAnimation();
            }
            else
            {
                jumpAnimation();
            }
        }
    }

    public void getDamage(int damage)
    {
        if (isInvincible) return;

        GameManager.Instance.AudioManager.Play("PlayerDamaged");

        StartCoroutine(makeInvincible(1f));

        StatsSO.HP -= damage;
        if(StatsSO.HP <= 0)
        {
            Debug.Log("DEATH");
        }
    }

    private void jumpAnimation()
    {
        animator.Play("Player_Jump");
    }

    private void walkAnimation()
    {
        animator.Play("Player_Walk");
    }

    private void idleAnimation()
    {
        animator.Play("Player_Idle");
    }

    public IEnumerator waitForChangeWeapon()
    {
        canChangeWeapon = false;
        yield return new WaitForSeconds(0.5f);
        canChangeWeapon = true;
        yield break;
    }
    public IEnumerator makeInvincible(float time)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        isInvincible = false;
        yield break;
    }
}
