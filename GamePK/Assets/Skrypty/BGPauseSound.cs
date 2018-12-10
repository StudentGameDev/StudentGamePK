using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGPauseSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var bg = BGSound.Instance;
        if (bg != null)
            bg.gameObject.GetComponent<AudioSource>().Pause();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
