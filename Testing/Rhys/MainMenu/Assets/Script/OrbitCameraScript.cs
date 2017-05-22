using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraScript : MonoBehaviour {

	public float moveSpeed;
	public Transform target;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (target.position, target.up, -1 * moveSpeed * Time.deltaTime);
		transform.RotateAround (target.position, target.right, moveSpeed * Time.deltaTime);
		transform.LookAt (target);
	}
}
