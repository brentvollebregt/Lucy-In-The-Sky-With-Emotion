using UnityEngine;

public class GrabSpeaker : MonoBehaviour
{
    bool placing = false;
    public float distance = 1.5f;
    float speed = 10;
    Material material;
    float emission;
    public Color flashColor;
    private Color finalColor, baseColor;
    private ScaleWithAudio script;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        script = GetComponent<ScaleWithAudio>();
        baseColor = material.GetColor("_EmissionColor");
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        Debug.Log("Selected");
        AudioClip clip;
        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;
        
        if (placing)
        {
            clip = (AudioClip)Resources.Load("ClickOn");
            //distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);            
            script.detail = 100;
        }
        else
        {
            clip = (AudioClip)Resources.Load("ClickOff");
            material.SetColor("_EmissionColor", baseColor);
            script.detail = 300;
        }

        AudioSource source = Camera.main.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            emission = Mathf.PingPong(Time.time * 2, 1.0f);

            finalColor = flashColor * Mathf.LinearToGammaSpace(emission);
            material.SetColor("_EmissionColor", finalColor);

            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));

            // Rotate this object's parent object to face the user.
            Quaternion toQuat = Camera.main.transform.localRotation;
            toQuat.x = 0;
            toQuat.z = 0;
            this.transform.rotation = toQuat;
        }
    }
}