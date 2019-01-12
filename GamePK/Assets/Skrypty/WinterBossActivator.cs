using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBossActivator : MonoBehaviour {

    public Rigidbody2D player;
    private Animator anim;
    public Rigidbody2D winterBoss;
    Vector2 startPosition;

    // Use this for initialization
    void Start () {
        winterBoss.gameObject.SetActive(false);
        startPosition = winterBoss.position;
    }

    // Update is called once per frame
    void Update () {
        if (player.position.x - startPosition.x > 5)
        {
            winterBoss.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        winterBoss.GetComponent<WinterBoss>().Reset();
        winterBoss.gameObject.SetActive(false);
    }
}
