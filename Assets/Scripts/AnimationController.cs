using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private enum MovementState { idle, running, jumping, falling};
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementState state;
        //if(Mathf.Abs(rb.velocity.x) > 0f)
        float dirx = Input.GetAxisRaw("Horizontal");
        if (dirx > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sr.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }else if(rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
