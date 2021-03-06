﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public Transform panel;
    public AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(panel.gameObject.activeInHierarchy == false)
            {
                Time.timeScale = 0;
                panel.gameObject.SetActive(true);
                audioSource.Pause();
            }
            else
            {
                panel.gameObject.SetActive(false);
                Time.timeScale = 1;
                audioSource.Play();
            }
        }
	}
}
