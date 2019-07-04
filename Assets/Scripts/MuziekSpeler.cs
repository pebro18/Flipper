using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuziekSpeler : MonoBehaviour {

    static MuziekSpeler instance = null;

    public AudioSource MpPlayer;
    public AudioClip[] MusicClip;
    

    // Use this for initialization
    void Start () {
		if (instance != null)
        {
            Destroy(gameObject);
            print("Destroy Mankind");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        MpPlayer.clip = MusicClip[0];      
        MpPlayer.Play();
        

    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void NextSong(int SongID) {

        MpPlayer.clip = MusicClip[SongID];
        if (!MpPlayer.isPlaying)
        {
            MpPlayer.Play();
        }

    }

}
