using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFOV : MonoBehaviour {
    Camera camera;
    int maxFOV = 179;
    int minFOV = 60;

    int crazyMaxFOV = 150;
    int crazyMinFOV = 40;

    bool crazy = false;
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        if (crazy == false & maxFOV > 60) 
        {
            camera.fieldOfView = Mathf.Lerp(maxFOV, minFOV, Time.deltaTime);
            maxFOV -= 1;
        }
        if (crazy == true)
        {
            if (crazyMaxFOV >= crazyMinFOV)
            {
                int min = crazyMinFOV;
                int max = crazyMaxFOV;
                camera.fieldOfView = Mathf.Lerp(max, min, Time.deltaTime);
                crazyMaxFOV -= 1;
            }
            else
            {
                int min = crazyMinFOV;
                int max = crazyMaxFOV;
                camera.fieldOfView = Mathf.Lerp(min, max, Time.deltaTime);
                crazyMaxFOV += 1;
            }
        }
        
	}

    public void SetCrazy()
    {
        crazy = !crazy;
    }
}
