//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//
//
//public class jsonReader : MonoBehaviour {
//	string jsonString, path;
//	List<Song> songList;
//	// Use this for initialization
//	void Start () {
//		songList = new List<Song> ();
//		ReadFileType1 ();
//
//	}
//	// Update is called once per frame
//	void Update () {
//	}
//	void ReadFileType1 (){
//		path = Application.streamingAssetsPath + "/visualiser_data.json";
//		jsonString = File.ReadAllText (path);
////		jsonString.TrimStart ('[').TrimEnd ('}',']');
////		//string[] songs = jsonString.Split("},");
////		string[] songs = jsonString.Split(new string[] { "}," }, System.StringSplitOptions.None);
////		for (int i = 0; i < songs.Length - 1; i++) {
////			songs[i] += "}";
////		}
////			
////
////		for (int i = 0; i < songs.Length; i++) {
////			songList.Add(JsonUtility.FromJson<Song>(songs[i]));
////			Debug.Log(songList [i].artist);
////		}
//		string [] songsList = JsonUtility.FromJson<Song>(jsonString).ToString().Split(new string[] { "}," }, System.StringSplitOptions.None);
//		Debug.Log(songList[0].artist);
//	}
//	void ReadFileType2(){
//	}
//}
//
////[System.Serializable]
////public class Song
////{
////	public string artist,title, file_location;
////	public double bpm, songLength, valence, energy;
////}
