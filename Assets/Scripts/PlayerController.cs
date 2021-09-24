using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private WeaponPivot weaponPivot;
    public float moveSpeed;
    public float maxJumpHeight;
    public float minJumpHeight;
    private Vector2 playerVelocity;
    private float moveDir;
    private bool hasDoubleJumped;
    private bool isGrounded;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck01;
    [SerializeField] private Transform groundCheck02;

    [SerializeField] private BoxCollider2D weaponCollider;

    public void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start() {
        
    }

    public void Update() {
        isGrounded = Physics2D.OverlapArea(groundCheck01.position, groundCheck02.position, whatIsGround);
        if (Input.GetButtonDown("Jump") && (isGrounded || !hasDoubleJumped)) {
            JumpCancel();
        }
        if (Input.GetButtonUp("Jump")) {
            Jump();
        }

        MoveLogic();

        if (isGrounded && rb.velocity.y <= 0.1f)
            hasDoubleJumped = false;

        if (Input.GetButtonDown("Fire2")) {
            //Attack logic
        }
    }
    private void MoveLogic() {
        moveDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDir * moveSpeed, rb.velocity.y);
    }
    private void Jump() {
         if(rb.velocity.y > 0 && rb.velocity.y < maxJumpHeight)
            rb.velocity = new Vector2(rb.velocity.x, minJumpHeight);
        }

    private void JumpCancel() {
        if (!isGrounded && !hasDoubleJumped)
            hasDoubleJumped = true;
        rb.velocity = new Vector2(rb.velocity.x, maxJumpHeight);
    }

}
