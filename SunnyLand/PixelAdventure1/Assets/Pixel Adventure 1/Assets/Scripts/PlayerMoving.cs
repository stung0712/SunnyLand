using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Transform groundCheck;
    

    private enum MovementState { idle, running, jumping, falling};
    [SerializeField] private AudioSource jumpSoundEffeect;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffeect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX= true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y >1f)
        {
            state = MovementState.jumping;
        } else if (rb.velocity.y < -1f) {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8902503f, 0.2505716f), CapsuleDirection2D.Horizontal, 0f, jumpableGround);
    }
        

}
