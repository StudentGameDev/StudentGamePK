using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D player, enemy;
    public Transform xStart;
    public Vector3 spawnPoint;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Rigidbody2D>();
        enemy.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(player.position.x >= xStart.position.x)
        {
            enemy.gravityScale = 1;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Gracz1")
        {
            collision.transform.position = spawnPoint;
        }
    }
}
