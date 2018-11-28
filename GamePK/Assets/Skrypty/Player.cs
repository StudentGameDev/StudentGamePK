using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D player;
    public float playerSpeed;
    public float playerJump;
    private bool playerDoubleJump;

    public Transform checkGround;
    public LayerMask isGround;
    public float groundIsRadius;    
    private bool grounded;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, groundIsRadius, isGround);
    }

    private void PlayerMove()
    {

        if (grounded)
        {
            playerDoubleJump = false;
        }

        // Strzałka w górę
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !grounded && !playerDoubleJump)
        {
            Jump();
            playerDoubleJump = true;
        }

        // Strzałka w lewo
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Strzałka w prawo
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Jump()
    {
        player.velocity = new Vector2(0, playerJump);
    }
}
