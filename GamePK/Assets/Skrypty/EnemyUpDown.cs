using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour {

    public Rigidbody2D enemy;
    public Transform yStart, yStop;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (enemy.position.y < yStop.position.y)
        {
            enemy.gravityScale = -0.3f;
        }
        if (enemy.position.y >= yStart.position.y)
        {
            enemy.gravityScale = 0.3f;
        }
    }
}
