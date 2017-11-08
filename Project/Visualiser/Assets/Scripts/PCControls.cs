using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PCControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GameObject g = InteractibleManager.Instance.FocusedGameObject;
            // Send an OnSelect message to the focused object and its ancestors.
            Debug.Log(g);
            if (g != null && GameObject.FindGameObjectsWithTag("Placeable").Contains(g))
            {
                g.SendMessageUpwards("Move");
            }
            else
            {
                SendMessageUpwards("MakeBall");
            }
        }
    }
}
