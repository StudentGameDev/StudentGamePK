using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBossLvl3 : MonoBehaviour
{

    private int bossHealth { get; set; }

    public GameObject BossLife1;
    //public GameObject BossLife2;
    //public GameObject BossLife3;

    public BossLevel3 bossik;

    // Use this for initialization
    void Start()
    {
        BossLife1 = GameObject.Find("BossLife1");
        //BossLife2 = GameObject.Find("BossLife2");
        //BossLife3 = GameObject.Find("BossLife3");
        bossik = FindObjectOfType<BossLevel3>();   // wyszukaj skrypt BossLevel3
        bossHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        BossLife();
    }

    public void ChangeEnergyBoss(int energyValue)
    {
        bossHealth += energyValue;
    }

    public int QuantityOfEnergy()
    {
        return bossHealth;
    }

    void BossLife()
    {
        //if (bossHealth == 3)
        //    BossLife3.GetComponent<Renderer>().enabled = true;
        //else
        //    BossLife3.GetComponent<Renderer>().enabled = false;

        //if (bossHealth >= 2)
        //    BossLife2.GetComponent<Renderer>().enabled = true;
        //else
        //    BossLife2.GetComponent<Renderer>().enabled = false;

        if (bossHealth >= 1)
            BossLife1.GetComponent<Renderer>().enabled = true;
        else
            BossLife1.GetComponent<Renderer>().enabled = false;
    }
}
