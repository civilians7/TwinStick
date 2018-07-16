using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager manager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.recording) {
            Record();
        } else {
            PlayBack();
        }

    }

    private void Record() {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }

    public void PlayBack() {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

/// <summary>
/// A structure for storing time, rotation, and position
/// </summary>
public struct MyKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation) {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}