using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public Vector3 respawnPoint;
    public float speed;
    private Rigidbody2D enemy;
    public Transform startX;
    public Transform stopX;
    public bool right;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        right = true;
    }

    void Update()
    {
        if (enemy.position.x < startX.position.x)
        {
            right = true;
        }

        if (enemy.position.x > stopX.position.x)
        {
            right = false;
        }

        if (right == true)
        {
            enemy.velocity = new Vector2(speed, enemy.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            enemy.velocity = new Vector2(-speed, enemy.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Gracz1")
        {
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.tag == "Gracz1")
    //    {
    //        collision.transform.position = respawnPoint;
    //    }
    //}
}
