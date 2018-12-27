using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBoss : MonoBehaviour {

    public float bossHealth;
    public GameObject BossLife1;
    public GameObject BossLife2;
    public GameObject BossLife3;

    Boss1 boss1;

    // Use this for initialization
    void Start () {
        BossLife1 = GameObject.Find("BossLife1");
        BossLife2 = GameObject.Find("BossLife2");
        BossLife3 = GameObject.Find("BossLife3");
        boss1 = FindObjectOfType<Boss1>();
    }
	
	// Update is called once per frame
	void Update () {
        BossLife();
        bossHealth = boss1.bossHealth;
    }

    void BossLife(/*float energyBoss*/)
    {
        if (bossHealth == 3)
            BossLife3.GetComponent<Renderer>().enabled = true;
        else
            BossLife3.GetComponent<Renderer>().enabled = false;

        if (bossHealth >= 2)
            BossLife2.GetComponent<Renderer>().enabled = true;
        else
            BossLife2.GetComponent<Renderer>().enabled = false;

        if (bossHealth >= 1)
            BossLife1.GetComponent<Renderer>().enabled = true;
        else
            BossLife1.GetComponent<Renderer>().enabled = false;
    }
}
