using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControls : MonoBehaviour
{
    SplineController controller;
    SplineInterpolator interpolater;
    public SmoothMouseLook smoothmouse;
    bool enabled;
    Vector3 CameraPosion;
    // Use this for initialization
    void Start()
    {
        CameraPosion = GetComponentInChildren<Transform>().transform.position;
        controller = GetComponent<SplineController>();
        interpolater = GetComponent<SplineInterpolator>();
        //smoothmouse = GetComponent<SmoothMouseLook>();
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            enabled = !enabled;
            controller.enabled = enabled;
            interpolater.enabled = enabled;
            smoothmouse.enabled = enabled;
        }
        

    }
}
