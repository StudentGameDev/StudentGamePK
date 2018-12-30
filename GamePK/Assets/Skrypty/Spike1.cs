﻿using System.Collections;
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
        if (spikeOne.position.x - player.position.x < 2)
            spikeOne.gravityScale = 1;
    }
}
