using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    bool flashing = false;
    Material material;
    float emission;
    public Color flashColor;
    private Color finalColor, baseColor;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        baseColor = material.GetColor("_EmissionColor");
        flashColor = Color.yellow;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    public void OnPlace()
    {
        // On each Select gesture, toggle whether the user is in placing mode.
        flashing = !flashing;

        if (!flashing)
        {
            material.SetColor("_EmissionColor", baseColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (flashing)
        {
            emission = Mathf.PingPong(Time.time * 2, 1.0f);

            finalColor = flashColor * Mathf.LinearToGammaSpace(emission);
            material.SetColor("_EmissionColor", finalColor);
        }
    }
}
