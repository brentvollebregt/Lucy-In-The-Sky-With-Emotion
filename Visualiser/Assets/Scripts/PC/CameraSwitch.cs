using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Camera orbitCamera;
    public bool switchCam = false;
    public SplineController contr;
    public SplineInterpolator inter;
    // Use this for initialization
    void Start()
    {
        mainCamera.GetComponent<Camera>().enabled = true;
        mainCamera.GetComponent<AudioListener>().enabled = true;
        orbitCamera.GetComponent<Camera>().enabled = false;
        orbitCamera.GetComponent<AudioListener>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switchCam = !switchCam;
        }
        if (switchCam)
        {
            contr.enabled = true;
            inter.enabled = true;
            mainCamera.GetComponent<Camera>().enabled = false;
            mainCamera.GetComponent<AudioListener>().enabled = false;
            orbitCamera.GetComponent<Camera>().enabled = true;
            orbitCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            Start();
        }
    }
}
