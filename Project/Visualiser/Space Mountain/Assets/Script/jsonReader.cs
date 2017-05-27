using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonReader : MonoBehaviour {

	public class JSONFILE
	{
		public string artist,title, file_location;
		public double bpm, songLength, valence, energy;
	}
	List<JSONFILE> jsonFiles;
	string json;

	// Use this for initialization
	void Start () {
		
		jsonFiles = new	List<JSONFILE> ();
		int songCount = Directory.GetFiles (Path.GetDirectoryName("/")).Length;
		for (int i = 1; i <= songCount; i++) {
			using (StreamReader r = new StreamReader ("song"+ i +".json")) {
				string json = r.ReadToEnd ();
				jsonFiles.Add (JsonUtility.FromJson<JSONFILE> (json));
			}
		}
		Debug.Log (jsonFiles.Count);
	}
	// Update is called once per frame
	void Update () {
		
	}
	void MoveJSON(){
		string sourceFile = "";
		string destinationFile = "";
	}
	void ReadJSON(){
	}

	public static long DirCount(DirectoryInfo d)
	{
		long i = 0;
		FileInfo[] fis = d.GetFiles();
		foreach (FileInfo fi in fis)
		{
			if (fi.Extension.Contains("json"))
				i++;
		}
		return i;
	}

}
