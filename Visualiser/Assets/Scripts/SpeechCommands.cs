using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechCommands : MonoBehaviour {

	void ResetSpeaker()
    {
        if (GameObject.FindGameObjectWithTag("Speaker").transform.parent.transform == this.gameObject.transform)
        //    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1.5f));
        SendMessage("Move");
    }

    void ResetLine()
    {
        if (GameObject.FindGameObjectWithTag("Line1").transform.parent.transform == this.gameObject.transform)
            //    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 1.5f));
            SendMessage("Move");
    }
}