using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel2 : MonoBehaviour
{

    [SerializeField] private string nextLevelWinter;

    public EnergyBoss energyBoss;
    

    private void Start()
    {
        //energyBoss = FindObjectOfType<EnergyBoss>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gracz1") && BossDefeated())
        {
            CoinScript.AddExtraPointsTime();
            ScoreScript.SaveCurrentStateToFile();            
            SceneManager.LoadScene(nextLevelWinter);
        }
    }

    private bool BossDefeated()
    {
        bool result = true;
        if (energyBoss != null)
            result = energyBoss.QuantityOfEnergy() <= 0;

        return result;
    }
}