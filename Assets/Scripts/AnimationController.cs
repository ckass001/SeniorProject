using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //if(Mathf.Abs(rb.velocity.x) > 0f)
        float dirx = Input.GetAxisRaw("Horizontal");
        if (dirx > 0f)
        {
            anim.SetBool("isRunning", true);
            sr.flipX = false;
        }
        else if (dirx < 0f)
        {
            anim.SetBool("isRunning", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
