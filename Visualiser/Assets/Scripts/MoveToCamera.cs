using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCamera : MonoBehaviour {
    private Vector3 startPos, endPos;
    bool moving = false, selected = false;
    public float speed = 1, time = 5, distance = 1.5f;
    private float currentTime = 0;
    public bool isLine = false;

	// Use this for initialization
	void Start () {
	    
	}

    void Move()
    {
        if (!selected)
            moving = true;
        else
            SendMessage("OnSelect");
        selected = !selected;
    }
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            startPos = this.transform.position;
            endPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));
            if (isLine)
                endPos.x -= 0.2f;
            currentTime += Time.deltaTime * speed;
            if (currentTime >= time - (time * 0.7)) 
            {
                currentTime = 0;
                moving = false;
                Debug.Log("finished");
                SendMessage("OnSelect");
            }
            float perc = currentTime / time; 
            this.transform.position = Vector3.Lerp(startPos, endPos, perc);
        }
	}
}
