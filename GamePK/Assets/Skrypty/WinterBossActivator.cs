using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBossActivator : MonoBehaviour {

    public Rigidbody2D player;
    private Animator anim;
    public Rigidbody2D winterBoss;
    float startPosition;

    // Use this for initialization
    void Start () {
        startPosition = winterBoss.position.x;
        winterBoss.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (startPosition - player.position.x < 5)
        {
            winterBoss.gameObject.SetActive(true);
        }
    }
}
