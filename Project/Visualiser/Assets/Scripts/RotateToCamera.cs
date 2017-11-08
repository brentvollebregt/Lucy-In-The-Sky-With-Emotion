using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour {
    private Transform target;
    private Quaternion rotation;
    private bool moving = false, selected = false;
    Vector3 lookPos;
    public float speed = 1, time = 5;
    private float currentTime = 0;
    private float damping = 2;

    // Use this for initialization
    void Start () {
        target = Camera.main.transform;
	}

    void Move()
    {
        if (!selected)
            moving = true;

        selected = !selected;
    }
	
	// Update is called once per frame
	void Update () {

        if (moving)
        {
            lookPos = target.position - transform.position;
            lookPos.y = 0;
            //rotation = Quaternion.LookRotation(lookPos);
            rotation = Camera.main.transform.localRotation;
            currentTime += Time.deltaTime * speed;

            if (currentTime >= time - (time * 0.75))
            {
                currentTime = 0;
                moving = false;
                Debug.Log("finished rotating");
                //SendMessage("OnSelect");
            }
            float perc = currentTime / time;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, perc);
        }
    }
}
