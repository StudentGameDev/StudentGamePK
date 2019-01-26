﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    private Transform player;
    private Vector2 target;
    LevelManager gameLevelManager;
    Player playerHealth;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Gracz1").transform;
        gameLevelManager = FindObjectOfType<LevelManager>();
        playerHealth = FindObjectOfType<Player>();
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gracz1"))
        {            
            DestroyProjectile();
            playerHealth.RespawnAndHealth();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
