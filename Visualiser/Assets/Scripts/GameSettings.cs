using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    private float gravity = -1f;
    private int numBalls = 0;
    public int maxBalls = 10;
    public static bool drawMeshes = true;
   
    // Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, gravity, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void ToggleMesh()
    {
        drawMeshes = !drawMeshes;
    }
}
