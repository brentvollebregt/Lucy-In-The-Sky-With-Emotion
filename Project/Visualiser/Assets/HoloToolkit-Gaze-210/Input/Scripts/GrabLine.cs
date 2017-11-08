using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Academy.HoloToolkit.Unity
{
    public class GrabLine : MonoBehaviour
    {
        
        bool placing = false;
        float distance, angle;       
        Vector3 positionDifference, placeGazeVector;
        Quaternion rotationDifference;
        Transform center;
        public GameObject Object
        {
            get { return this.gameObject; }
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
                //distance = Vector3.Distance(GazeManager.Instance.Position, Camera.main.transform.position);
                distance = 1.5f;
                BroadcastMessage("OnPlace");
            }
            else
            {
                clip = (AudioClip)Resources.Load("ClickOff");
                BroadcastMessage("OnPlace");
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
                this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance));
                this.transform.Translate(-0.2f, 0, 0);
                //this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distance)) + positionDifference;


                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
               
                this.transform.rotation = toQuat;
                //this.transform.rotation = Camera.main.transform.rotation * rotationDifference;
            }
        }
    }
}
