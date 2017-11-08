using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoodColorSun : MonoBehaviour {

	public ParticleSystem happySun_;
	public ParticleSystem sadSun_;
	public GameObject SongObject_;
	ParticleSystem.ColorOverLifetimeModule colour_;

	// Use this for initialization
	void Start () {
		colour_ = GetComponent<ParticleSystem> ().colorOverLifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (SongObject_.GetComponent<CSVReader>().currentSong.mood == "Sad") {
			colour_.color = sadSun_.colorOverLifetime.color;
		} else {
			colour_.color = happySun_.colorOverLifetime.color;
		}
	}
}
