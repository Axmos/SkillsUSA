using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMaker : MonoBehaviour {
    public AudioClip[] music;
    AudioSource myAudioSource;
    public static MusicMaker instance;

    // Use this for initialization
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            DestroyImmediate(gameObject);
        }
        
    }
    
  
    void Start () {
        PlaySong();

    }
	
	// Update is called once per frame
	void Update () {
        if (!myAudioSource.isPlaying) {
            PlaySong();
        }
    }
    void PlaySong() {
        myAudioSource = GetComponent<AudioSource>();
        int m = Random.Range(0, music.Length);
        myAudioSource.PlayOneShot(music[m]);
        
    }
}
