﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    AudioSource JumpSource;

    private Rigidbody2D player;
    public float playerSpeed;
    public float playerJump;
    private bool blockJump;

    public Transform checkGround;
    public LayerMask isGround;
    public float groundIsRadius;    
    private bool grounded;
    private Animator anim;
    private Camera mainCamera;
    private float cameraWidth;
    private const int playerSize = 1;
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        SetCamera();
    }

    // Ustawia właściwości kamery podoążającej za graczem
    private void SetCamera()
    {
        mainCamera = Camera.main;
        float height = 2f * mainCamera.orthographicSize;
        cameraWidth = height * mainCamera.aspect;
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
            blockJump = false;
        }
        anim.SetBool("Grounded", grounded);

        // Strzałka w górę
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Debug.Log("TEST");
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !grounded && !blockJump)
        {
            Debug.Log("TEST");
            Jump();
            blockJump = true;
        }

        // Strzałka w lewo
        if (Input.GetKey(KeyCode.LeftArrow) && (player.transform.position.x >= mainCamera.transform.position.x + playerSize - cameraWidth / 2))
        {
            player.velocity = new Vector2(-playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Strzałka w prawo
        if (Input.GetKey(KeyCode.RightArrow) && (player.transform.position.x < mainCamera.transform.position.x - playerSize + cameraWidth / 2))
        {
            player.velocity = new Vector2(playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // obrót w prawo
        if (player.velocity.x > 0.1f)
        {
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        // obrót w lewo
        else if (player.velocity.x < -0.1f)
        {
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        // animacja ruchu
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    void Jump()
    {
        player.velocity = new Vector2(0.0001f, playerJump);
        JumpSource.Play();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            gameLevelManager.LessHealth();
            gameLevelManager.Respawn();
        }
        if (other.tag == "CheckPoint")
        {
            respawnPoint = other.transform.position;
        }
        if (other.tag == "Mace1" || other.tag == "Mace2" || other.tag == "Saw1" || other.tag == "Spike1" || other.tag == "Spike2" || other.tag == "Spike_Up1")
        {
            gameObject.transform.position = respawnPoint;
        } 
    }

    // kolizja z ptakami
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Postac1")
        {
            gameObject.transform.position = respawnPoint;
        }
    }  
}
