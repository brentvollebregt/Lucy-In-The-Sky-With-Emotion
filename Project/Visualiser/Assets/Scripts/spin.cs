using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
	public float speed;
	Vector3 spinDirection;
	// Use this for initialization
	void Start () {
		spinDirection = new Vector3(10, 10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(spinDirection*Time.deltaTime*speed);
	}
}
