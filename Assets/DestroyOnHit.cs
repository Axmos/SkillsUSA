using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {
	public int damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision col) {
		if(col.gameObject.CompareTag("Player")) {
			col.gameObject.GetComponent<Health> ().GotHit (damage);
		}
		Destroy (gameObject);
	}
}
