using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDown : MonoBehaviour {

    int direction = 1; //int direction where 0 is stay, 1 up, -1 down    
    int top = 6;
    int bottom = -7;

    float speed = 5;
    Rigidbody2D enemy;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y >= top)
        {
            enemy.gravityScale = 1;
            direction = -1;
        }
            

        if (transform.position.y <= bottom)
        {
            enemy.gravityScale = -1;
            direction = 1;
        }


        transform.Translate(0, speed * direction * Time.deltaTime, 0);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.name == "Gracz1")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
