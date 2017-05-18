using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	[SerializeField]
	Camera mainCamera;
	[SerializeField]
	Camera orbitCamera;
	private bool switchCam = false;
	// Use this for initialization
	void Start () {
		mainCamera.GetComponent<Camera> ().enabled = true;
		orbitCamera.GetComponent<Camera> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			switchCam = !switchCam;
		}
		if (switchCam) {
			mainCamera.GetComponent<Camera> ().enabled = false;
			orbitCamera.GetComponent<Camera> ().enabled = true;
		} else {
			Start ();
		}
	}
	
}
