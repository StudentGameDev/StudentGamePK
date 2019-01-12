using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike1 : MonoBehaviour {

    public Rigidbody2D player, spikeOne;
    public int SpikeToPlayerFallX;

    // Use this for initialization
    void Start()
    {

        spikeOne = GetComponent<Rigidbody2D>();
        spikeOne.gravityScale = 0;
        if (SpikeToPlayerFallX == 0)
            SpikeToPlayerFallX = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (spikeOne.position.x - player.position.x < SpikeToPlayerFallX)
            spikeOne.gravityScale = 1;
    }
}
