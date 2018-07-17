using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
	}

    void LateUpdate() {
        transform.LookAt(player);
            
    }
}
