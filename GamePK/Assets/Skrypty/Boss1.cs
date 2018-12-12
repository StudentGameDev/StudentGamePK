using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    private Animator anim;
    public float speed, predkoscZmianaAnimacji;
    public Rigidbody2D boss, player;
    public Transform startX, stopX;
    public bool isRight;
    

    void Start()
    {
        boss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isRight = true;
        speed = 5;
    }

    void Update()
    {
        /*Przeciwnik porusza się do określonego momentu dopóki gracz nie osiągnie odpowiedniego punktu*/
        if (player.position.x < startX.position.x || player.position.x > stopX.position.x || player.position.x <= (boss.position.x - 4f) || player.position.x >= (boss.position.x + 4f))
            MoveLeftOrRight();
        else if(player.position.x > (boss.position.x - 4.0f) || player.position.x < (boss.position.x + 4f))
        {
            predkoscZmianaAnimacji = 0;
            boss.velocity = new Vector2(predkoscZmianaAnimacji, boss.velocity.y);
            anim.SetFloat("Speed", predkoscZmianaAnimacji);
        }
            
       
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
