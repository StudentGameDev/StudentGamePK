using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

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
            // idz w prawo
            right = true;
        }

        if (enemy.position.x > stopX.position.x)
        {
            // idz w lewo
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
}
