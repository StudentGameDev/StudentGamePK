using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private Animator anim;
    public Transform[] controlPoints;
    public float moveSpeed;
    private int currentPoint;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        transform.position = controlPoints[0].position;
        currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == controlPoints[currentPoint].position)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            currentPoint++;
        }
        if(currentPoint >= controlPoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, controlPoints[currentPoint].position, moveSpeed = Time.deltaTime);
        }
	}
}
