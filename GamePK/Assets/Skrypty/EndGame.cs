using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour {

    [SerializeField] private string Menu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gracz1"))
        {
            CoinScript.AddExtraPointsTime();
            ScoreScript.SaveCurrentStateToFile();
            SceneManager.LoadScene(Menu);
        }
    }
}
