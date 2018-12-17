using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike2 : MonoBehaviour {

    public Rigidbody2D spikeTwo;
	// Use this for initialization
	void Start () {
        spikeTwo = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Gracz1")
            Destroy(gameObject);
    }
}
