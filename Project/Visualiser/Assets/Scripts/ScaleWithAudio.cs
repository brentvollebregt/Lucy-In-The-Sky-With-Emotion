using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleWithAudio : MonoBehaviour {

    public int detail = 500;
    public float minValue = 1.0f;
    public float amplitude = 0.1f;

    private float randomAmplitude = 1.0f;
    private Vector3 startScale;

    private bool started = false;


	// Use this for initialization
	void Start () {
        startScale = transform.localScale;

        Invoke("StartRoutine", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            float[] info = new float[detail];
            AudioListener.GetOutputData(info, 0);
            float packagedData = 0.0f;

            for (int x = 0; x < info.Length; x++)
            {
                packagedData += System.Math.Abs(info[x]);
            }

            transform.localScale = new Vector3((packagedData * amplitude) + startScale.y, (packagedData * amplitude) + startScale.y, (packagedData * amplitude) + startScale.z);
        }
    }

    private void StartRoutine()
    {
        started = true;
    }
}
