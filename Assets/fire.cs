using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

    public float min, max, timer, multi, speed;
	public GameObject ball, spawn, fakeBall, target;
	public bool firing;
	public Vector3 spawnpoint;

	// Use this for initialization
	void Start () {
		spawnpoint = spawn.transform.position;
	}

    // Update is called once per frame
    void Update() {
			spawnpoint = spawn.transform.position;
            if (Input.GetKey(KeyCode.Space)) {   
                if (transform.rotation.eulerAngles.x < min) {
				fakeBall.gameObject.GetComponent<MeshRenderer> ().enabled = true;
                    gameObject.transform.Rotate(2f, 0f, 0f);
					firing = true;
                }
           } else {
			if (transform.rotation.eulerAngles.x > max) {
				multi = (transform.rotation.eulerAngles.x - max);
				gameObject.transform.Rotate(-10f,0f,0f);
				if(firing) {
					fakeBall.gameObject.GetComponent<MeshRenderer> ().enabled = false;
					GameObject current = Instantiate (ball, spawnpoint, Quaternion.identity);

					current.GetComponent<Rigidbody> ().AddForce (((transform.forward + (transform.up * -1)) * multi * speed) * -1);

				}
				firing = false;
            }
        }

		fakeBall.transform.position = Vector3.MoveTowards (fakeBall.transform.position, target.transform.position, 100 * Time.deltaTime);
    }
}


