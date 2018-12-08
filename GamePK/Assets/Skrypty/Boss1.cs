using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    private Animator anim;
    public float speed;
    public Rigidbody2D boss, player;
    public Transform startX;
    public Transform stopX;
    public bool right, seePlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        right = true;
        seePlayer = false;
    }

    void Update()
    {
        if ((boss.position.x - player.position.x) <= 3)
            anim.SetBool("SeePlayer", seePlayer);

        if (boss.position.x < startX.position.x)
        {
            // idz w prawo
            right = true;
        }

        if (boss.position.x > stopX.position.x)
        {
            // idz w lewo
            right = false;
        }

        if (right == true)
        {
            boss.velocity = new Vector2(speed, boss.velocity.y);  // ustawienie prędkości
            transform.localScale = new Vector3(1f, 1f, 1f);       // kierunek 
        }
        else
        {
            boss.velocity = new Vector2(-speed, boss.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }
}
