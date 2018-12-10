using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour {

    private Rigidbody2D element;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float yMin;


    // Use this for initialization
    void Start () {
        element = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update () {
		
	}
}
