using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    [SerializeField]
    private Transform transformA;


    // Use this for initialization
    void Start () {
        posA = transformA.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition, nextPos) <= 1.0)
        {
            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
