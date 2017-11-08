using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BinExplosion : MonoBehaviour {
    ScaleWithAudio script;
    Rigidbody rigidbody;
    System.Random rand;
	// Use this for initialization
	void Start () {
        script = GetComponent<ScaleWithAudio>();
        rigidbody = GetComponent<Rigidbody>();
	}
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Bin")
        {
            Debug.Log("Collided");
            script.enabled = false;
        }
    }

    void OnBoom()
    {
        script.enabled = true;
        rigidbody.AddForce(0, 6, 0, ForceMode.Impulse);
    }
}
