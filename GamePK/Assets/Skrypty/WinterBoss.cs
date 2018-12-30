using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBoss : MonoBehaviour {

    private Rigidbody2D winterBoss;
    // Use this for initialization
    void Start () {
        winterBoss = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        winterBoss.velocity = new Vector2(5, GetComponent<Rigidbody2D>().velocity.y);
    }
}
