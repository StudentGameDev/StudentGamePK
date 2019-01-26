using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel3 : MonoBehaviour {

    public float speed, stoppingDistance, retreatDistance;
    public float distance;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    public EnergyBossLvl3 energyBossLvl3;
    public BlockDoor blockDoor;
    LevelManager gameLevelManager;
    Player playerHealth;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Gracz1").transform;
        gameLevelManager = FindObjectOfType<LevelManager>();
        playerHealth = FindObjectOfType<Player>();
        timeBtwShots = startTimeBtwShots;
        energyBossLvl3 = FindObjectOfType<EnergyBossLvl3>();
        blockDoor = FindObjectOfType<BlockDoor>();
    }
	
	// Update is called once per frame
	void Update () {

        if(gameLevelManager.QuantityOfEnergy() != 0)
        {
            if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }
        else
        {
            gameLevelManager.Restart();
        }
	}

    void OnTriggerEnter2D(Collider2D collision) // pokonanie bossa, edge collider
    {
        if (collision.name == "Gracz1")
        {
            energyBossLvl3.ChangeEnergyBoss(-1);
            if (energyBossLvl3.QuantityOfEnergy() == 0)
            {
                Destroy(gameObject);
                blockDoor.DestroyDoor();
            }
        }
    }
}
