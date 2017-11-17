using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CSVReader : MonoBehaviour {
	List<Song> songs_;
	string songData_;
	Song currentSong_;
	public Text UIDisplayText_;
    public Text Controls;
    public AudioSource source;
    int currentSongNum = 1;

	// Use this for initialization
	void Start () {
        //string cvsText = File.ReadAllText (Application.streamingAssetsPath + "/visualiser_data.csv");
        songs_ = new List<Song>();
        source.clip = (AudioClip)Resources.Load("1");
        source.Play();
		StreamReader cvsText = new StreamReader(new FileStream(Application.streamingAssetsPath + "/visualiser_data.csv", FileMode.Open));
		while ((songData_ = cvsText.ReadLine ()) != null) {
			string[] words = songData_.Split(',');
			songs_.Add (new Song (words[0],words[1], double.Parse(words[2]),double.Parse(words[3]),double.Parse(words[4]),double.Parse(words[5]),words[6],words[7]));
		

        
	}
        SetCurrentSong();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") > 0) {
			UIDisplayText_.text = currentSong_.ToString ();
            Controls.enabled = true;
//			UIDisplayText_.text = "Reeeeeeeee";
		} else {
			UIDisplayText_.text = "";
            Controls.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousSong();
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
                NextSong();
        if (Input.GetKeyDown(KeyCode.V))
        {
            
            if (currentSong_.mood == "Happy")
            {
                currentSong_.mood = "Sad";
                
            }
            else
                currentSong_.mood = "Happy";


        }
            


    }
		public void NextSong(){
			if (songs_.Count > 0) {
				//songs_.RemoveAt (0);
				SetCurrentSong ();
			} else {
				Finished ();
			}
		}
	void SetCurrentSong(){
        
		currentSong_ = songs_ [currentSongNum-1];       
        source.clip = (AudioClip)Resources.Load(currentSongNum.ToString());
        source.Play();
        currentSongNum++;
    }

    void PreviousSong()
    {
        if (currentSongNum > 2)
        {
            currentSongNum -= 2;
            SetCurrentSong();
        }
    }
	void Finished(){
	}
	public Song currentSong{
		get{return currentSong_; }
	}
}
	public class Song
	{
		string artist_,title_, fileName_, mood_;
		double bpm_, songLength_, valence_, energy_;

		public Song(string title, string artist, double bpm, double energy, double valence,double song_length,string mood,string fileName)
		{
			title_ = title;
			artist_ = artist;
			bpm_ = bpm;
			energy_ = energy;
			valence_ = valence;
			songLength_ = song_length;
			mood_ = mood;
			fileName_= fileName;
			Debug.Log(this.title_);
		}
		public override string ToString ()
		{
			return string.Format ("Title: {0} \nArtist: {1}\nBPM: {2}\nEnergy: {3}\nValence: {4}\nMood: {5}",title_, artist_,bpm_,energy_,valence_,mood_);
		}
		public string title{ get { return title_; } }
		public string artist{ get { return artist_; } }
		public double bpm{ get { return bpm_; } }
		public double energy{ get { return energy_; } }
		public double valence{ get { return valence_; } }
		public double songLength{ get { return songLength_; } }
		public string mood{ get { return mood_; }
                            set { mood_ = value; }
    }
		public string fileName{ get { return fileName_; } }
	}
