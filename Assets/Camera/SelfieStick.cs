using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 10f;

    private Transform player;
    private Vector3 armRotation;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
        armRotation = transform.rotation.eulerAngles;
	}

    void Update() {
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;
        transform.position = player.position;
        transform.rotation = Quaternion.Euler(armRotation);
            
    }
}
