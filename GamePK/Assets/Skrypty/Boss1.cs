using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    private Animator anim;
    public float speed, predkoscZmianaAnimacji;
    public Rigidbody2D boss, player;
    public Transform startX, stopX;
    public bool isRight;
    public Vector3 spawnPoint;
    public EnergyBoss energyBoss;


    //public float bossHealth;

    void Start()
    {
        energyBoss = FindObjectOfType<EnergyBoss>();
        boss = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isRight = true;
        speed = 5;
    }

    void Update()
    {
        /*Przeciwnik porusza się do określonego momentu dopóki gracz nie osiągnie odpowiedniego punktu*/
        if (player.position.x < startX.position.x || player.position.x > stopX.position.x || player.position.x <= (boss.position.x - 4f) || player.position.x >= (boss.position.x + 4f))
        {
            MoveLeftOrRight();
            predkoscZmianaAnimacji = 5.0f;
            anim.SetFloat("Speed", predkoscZmianaAnimacji);
            
        }
            
        else if(player.position.x > (boss.position.x - 4.5))
        {
            ChangeAnimation();
            if(isRight)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(player.position.x < (boss.position.x + 4.5))
        {
            ChangeAnimation();
            if(isRight)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) // kolizja gracza z mieczem
    {
        if (collision.transform.tag == "Gracz1")
        {
            collision.transform.position = spawnPoint;
            //Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) // pokonanie bossa, edge collider
    {

        if (collision.name == "Gracz1")
        {
            energyBoss.ChangeEnergyBoss(-1);
            if(energyBoss.QuantityOfEnergy() == 0)
                Destroy(gameObject);
        }
    }

    private void ChangeAnimation()
    {
        predkoscZmianaAnimacji = 0.0f;
        boss.velocity = new Vector2(predkoscZmianaAnimacji, boss.velocity.y);
        anim.SetFloat("Speed", predkoscZmianaAnimacji);
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

        if (isRight == true)  // poruszanie w prawo
        {
            boss.velocity = new Vector2(speed, boss.velocity.y);  // ustawienie prędkości
            transform.localScale = new Vector3(1f, 1f, 1f);       // kierunek 
        }
        else // w lewo
        {
            boss.velocity = new Vector2(-speed, boss.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    
}
