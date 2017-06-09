using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRotation : MonoBehaviour {

    Transform theChild;
    Transform theParent;
	// Use this for initialization
	void Start () {
        theChild = GetComponent<Transform>();
        theParent = theChild.GetComponentInParent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        theParent = theChild;
    }
}
