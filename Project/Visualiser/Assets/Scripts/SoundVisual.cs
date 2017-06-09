using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour {

    public float rmsValue;
    public float dbValue;
    public float pitchValue;
    public float visualModifier = 50.0f;
    public float smoothSpeed = 10.0f;
    public float maxVisualScale = 25.0f;
    public float keepPercentage = 0.5f;
    public Transform root;
    public Material[] materials = new Material[6];
    public CSVReader csvreader;


    private const int SAMPLE_SIZE = 1024;
    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;
    private bool happy = true;
    Renderer rend;

    public Transform[] visualList;
    private float[] visualScale;
    public int amnVisual = 64;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;
        SpawnLine();
        //SpawnCircle();
	}

    private void SpawnLine()
    {
        visualScale = new float[amnVisual];
        visualList = new Transform[amnVisual];

        for (int i = 0; i < amnVisual; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            go.transform.position = root.position;
            
            Material mat = materials[i % 3];
            rend = go.GetComponent<Renderer>();
            rend.material = mat;
            root.Translate(5, 0, 0);
            visualList[i] = go.transform;
            go.tag = "Cube";
            //visualList[i].position = Vector3.right * i;
        }
    }

    private void SpawnCircle()
    {
        visualScale = new float[amnVisual];
        visualList = new Transform[amnVisual];

        Vector3 center = root.transform.position;
        float radius = 10.0f;

        for (int i = 0; i < amnVisual; i++)
        {
            float ang = i * 1.0f / amnVisual;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Sin(ang) * radius;

            Vector3 pos = center + new Vector3(x, y, 0);
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            go.transform.position = pos;
            go.transform.rotation = Quaternion.LookRotation(Vector3.forward,pos);
            visualList[i] = go.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        AnalyzeSound();
        
        UpdateVisual();
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeMaterial(happy);
            happy = !happy;
        }
	}

    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)((SAMPLE_SIZE * keepPercentage) / amnVisual);

        while (visualIndex < amnVisual)
        {
            int j = 0;
            float sum = 0;
            while(j<averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualModifier;
            visualScale[visualIndex] -= Time.deltaTime * smoothSpeed;

            if (visualScale[visualIndex] < scaleY)
                visualScale[visualIndex] = scaleY;

            if (visualScale[visualIndex] > maxVisualScale)
                visualScale[visualIndex] = maxVisualScale;

            visualList[visualIndex].localScale = new Vector3(5,5,5) + Vector3.up * visualScale[visualIndex];
            visualIndex++;
        }
    }
    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //get the rms value
        
        float sum = 0;
        for (int i = 0; i < SAMPLE_SIZE; i++)
        {
            sum += samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //get the db value
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //get the sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //get the pitch
        float maxV = 0;
        var maxN = 0;
        for (int i = 0; i < SAMPLE_SIZE; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                continue;

            maxV = spectrum[i];
            maxN = i;
        }

        float freqN = maxN;
        if(maxN > 0 && maxN < SAMPLE_SIZE-1)
        {
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL - dL);
        }
        pitchValue = freqN * (sampleRate / 2) / SAMPLE_SIZE;
    }
    
    public void ChangeMaterial(bool mood)
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        Material mat;
        Renderer rend;

        if (!mood)
        {
            for (int i = 0; i<amnVisual; i++)
            {
                mat = materials[i % 3];
                rend = cubes[i].GetComponent<Renderer>();
                rend.material = mat;
            }            
        }
        else
        {
            for (int i = 0; i < amnVisual; i++)
            {
                mat = materials[(i%3) + 3 ];
                rend = cubes[i].GetComponent<Renderer>();
                rend.material = mat;
            }        
        }
    }
}
