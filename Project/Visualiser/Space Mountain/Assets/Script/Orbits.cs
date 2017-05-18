using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour {

	public int orbitPath;
	public float moveSpeed;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (orbitPath) {
		case(1): transform.RotateAround (target.position, target.right, moveSpeed * Time.deltaTime);
			break;
		case(2): transform.RotateAround (target.position, target.right, -1 * moveSpeed * Time.deltaTime);
			break;
		case(3): transform.RotateAround (target.position, target.up, moveSpeed * Time.deltaTime);
			transform.RotateAround (target.position, target.right, moveSpeed * Time.deltaTime);
			break;
		case(4): transform.RotateAround (target.position, target.up, -1 * moveSpeed * Time.deltaTime);
			break;
		default:
			break;
		}
	}
}
