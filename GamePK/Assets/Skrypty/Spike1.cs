using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike1 : MonoBehaviour {

    public Rigidbody2D player, spikeOne;

    // Use this for initialization
    void Start()
    {
        spikeOne = GetComponent<Rigidbody2D>();
        spikeOne.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= 77)
            spikeOne.gravityScale = 1;
    }
}
