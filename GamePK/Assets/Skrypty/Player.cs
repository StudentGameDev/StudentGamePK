using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float playerSpeed;
    public float playerJump;
    private Rigidbody2D player;
    public bool onGround;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        onGround = true;
    }

    private void PlayerMove()
    {
        // Strzałka w górę
        if(onGround == true) { 
            if (Input.GetKey(KeyCode.UpArrow))
            {
            
                player.velocity = new Vector2(0, playerJump);
                onGround = false;
            }
        }

        // Strzałka w dół
        if (Input.GetKey(KeyCode.DownArrow))
        {

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
}
