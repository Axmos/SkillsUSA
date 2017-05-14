using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {
	public int damage = 1;
    public int whoShotThis;
    AudioSource myAudioSource;
    public AudioClip hitSound;
	// Use this for initialization
	void Start () {
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col) {
        
		if(col.gameObject.CompareTag("Player")) {
            if (!(col.gameObject.GetComponent<Health>().whoAmI == whoShotThis)) {
                myAudioSource.PlayOneShot(hitSound);
                col.gameObject.GetComponent<Health>().GotHit(damage, whoShotThis);
            }
		}
        if (!myAudioSource.isPlaying) {
            Destroy(gameObject);
        }
	}
}
