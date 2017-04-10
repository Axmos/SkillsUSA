using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public float min, max;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        Debug.Log(transform.rotation.eulerAngles.x);
            if (Input.GetKey(KeyCode.Space)) {   
                if (transform.rotation.eulerAngles.x < min) {
                    gameObject.transform.Rotate(2f, 0f, 0f);
                }
           } else {
                    if (transform.rotation. < max) {
                        gameObject.transform.Rotate;
            }
        }
    }
}

