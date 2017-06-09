using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWithTempo : MonoBehaviour
{

    Light light;
    public Color happy;
    public Color sad;
    public double bpm;
    public GameObject TheCube;
    double baseIntensity = 0.1;
    double period;
    int multiplier = 1;
    double increment = 0.05;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        bpm = TheCube.GetComponent<CSVReader>().currentSong.bpm;
        period = bpm / 60;
        if (TheCube.GetComponent<CSVReader>().currentSong.mood == "Sad")
        {
            light.color = sad;
        }
        else
        {
            light.color = happy;
        }
        UpdateLight();
        //light.intensity = 0.2f + 5f * (Mathf.Cos((float)(Mathf.PI * 2 * 120 / 60))*Time.deltaTime);
    }
    void UpdateLight()
    {
        light.intensity += (float)(increment * multiplier * Time.deltaTime * period * 8);
        if (light.intensity > 0.4)
            multiplier = -1;
        else if (light.intensity < 0.1)
            multiplier = 1;
    }

}
