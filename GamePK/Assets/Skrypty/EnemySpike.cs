using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour {

    public Rigidbody2D player, enemy;
    public Transform xStart;
    public Vector3 spawnPoint;

    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.position.x >= xStart.position.x)
            enemy.gravityScale = 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Gracz1")
        {
            collision.transform.position = spawnPoint;
        }
    }
}
