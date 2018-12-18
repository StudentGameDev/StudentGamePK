using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    CheckPoint checkPoint = new CheckPoint();

    public Rigidbody2D player, enemy;
    public Transform xStart;
    //public Vector3 respawnPoint;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Rigidbody2D>();
        enemy.gravityScale = 0;
        //respawnPoint = checkPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(player.position.x >= xStart.position.x)
        {
            enemy.gravityScale = 1;
        }
	}

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.name == "Gracz1")
    //    {
    //        //respawnPoint = checkPoint.transform.position;
    //        collision.transform.position = respawnPoint;
    //    }
    //}
}
