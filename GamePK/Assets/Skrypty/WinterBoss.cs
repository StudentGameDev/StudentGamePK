using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBoss : MonoBehaviour {

    public Rigidbody2D player;
    private Animator anim;
    private Rigidbody2D winterBoss;
    bool run = false;
    float startPosition;
    public float bossSpeed;
    public float bossJump;
    private bool grounded;
    public float groundIsRadius;
    public LayerMask isGround;
    public Transform checkGround;


    // Use this for initialization
    void Start () {
        winterBoss = GetComponent<Rigidbody2D>();
        startPosition = winterBoss.position.x;
        winterBoss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("Grounded", true);
        anim.SetFloat("Speed", 0.0f);
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, groundIsRadius, isGround);
    }
    // Update is called once per frame
    void Update () {

        anim.SetBool("Grounded", grounded);

        if (winterBoss.position.x > startPosition + 2 && winterBoss.position.x < startPosition + 5)
            {
                Jump();

            }
            else {
                winterBoss.velocity = new Vector2(bossSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }

    void Jump()
    {
        winterBoss.velocity = new Vector2(bossSpeed, bossJump);
    }
}
