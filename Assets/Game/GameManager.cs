using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    public bool isPaused = false;
    private float fixedDeltaTime;

	// Use this for initialization
	void Start () {
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetAxis("Fire1") > .3){
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            if (!isPaused) {
                isPaused = true;
                PauseGame();
            } else {
                isPaused = false;
                ResumeGame();
            }
        }
      
	}

    void PauseGame() {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame() {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }
}
