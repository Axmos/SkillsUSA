using UnityEngine;
using System.Collections;

public class phasingScript : MonoBehaviour {
    public bool phasing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("e") && phasing == false) {
            phasing = true;
            gameObject.layer = LayerMask.NameToLayer("Phasing");
        } else if (Input.GetKeyDown("e") && phasing) {
            phasing = false;
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
	}
}
