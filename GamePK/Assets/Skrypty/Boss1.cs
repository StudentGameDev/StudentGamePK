using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    private Animator anim;
    public float speed;
    public Rigidbody2D boss, player;
    public Transform startX, stopX;
    public bool isRight, isClose;

    void Start()
    {
        boss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isRight = true;
        isClose = false;
    }

    void Update()
    {
        /*Przeciwnik porusza się do określonego momentu dopóki gracz nie osiągnie odpowiedniego punktu*/
        if (player.position.x < startX.position.x || player.position.x > stopX.position.x || player.position.x < (boss.position.x - 4.5f) || player.position.x > (boss.position.x + 4.5f))
            MoveLeftOrRight();
        else //if //(player.position.x > startX.position.x && player.position.x < stopX.position.x || player.position.x >= (boss.position.x - 3f))
            anim.SetFloat("Speed", 0.0f);
        //anim.SetBool("IsClose", isClose);

        //Destroy(gameObject);

        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //if (player.position.x )
        //  anim.SetBool("SeePlayer", seePlayer);
    }

    private void MoveLeftOrRight()
    {
        if (boss.position.x < startX.position.x)
        {
            // idz w prawo
            isRight = true;
        }

        if (boss.position.x > stopX.position.x)
        {
            // idz w lewo
            isRight = false;
        }

        if (isRight == true)
        {
            boss.velocity = new Vector2(speed, boss.velocity.y);  // ustawienie prędkości
            transform.localScale = new Vector3(1f, 1f, 1f);       // kierunek 
        }
        else
        {
            boss.velocity = new Vector2(-speed, boss.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
