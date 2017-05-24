using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {
    
    public float max, min, timer;
    public float multi;
    public float speed;
	public GameObject ball, spawn, fakeBall, target, indicator, rangePlane;
	public bool firing;
	public Vector3 spawnpoint;
    public int whichPlayer;
	// Use this for initialization
	void Start () {
		spawnpoint = spawn.transform.position;
	}

    // Update is called once per frame
    void Update() {
        spawnpoint = spawn.transform.position;
        if (whichPlayer == 1) {
            //multi = (transform.rotation.eulerAngles.x - min);
            if (Input.GetAxisRaw("Fire1") > 0.5f) {
                if (transform.rotation.eulerAngles.x < max) {
                    fakeBall.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    gameObject.transform.Rotate(2f, 0f, 0f);
                    firing = true;
                    rangePlane.SetActive(true);
                }
            } else {
                if (transform.rotation.eulerAngles.x > min) {
                    multi = (transform.rotation.eulerAngles.x - min);
                    gameObject.transform.Rotate(-10f, 0f, 0f);
                    if (firing) {
                        fakeBall.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        GameObject current = Instantiate(ball, spawnpoint, Quaternion.identity);

                        current.GetComponent<Rigidbody>().AddForce((((transform.forward) + (transform.up * -1)) * multi * speed) * -1);
                        current.GetComponent<DestroyOnHit>().whoShotThis = whichPlayer;
                        rangePlane.GetComponent<rangePlaneStretcher>().Shot();
                        
                    }
                    firing = false;
                }
            }
        } else if (whichPlayer == 2) {
            if (Input.GetAxisRaw("Fire2") > 0.5f) {
                if (transform.rotation.eulerAngles.x < max) {
                    fakeBall.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    gameObject.transform.Rotate(2f, 0f, 0f);
                    firing = true;
                    rangePlane.SetActive(true);
                }
            } else {
                if (transform.rotation.eulerAngles.x > min) {
                    multi = (transform.rotation.eulerAngles.x - min);
                    gameObject.transform.Rotate(-10f, 0f, 0f);
                    if (firing) {
                        fakeBall.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        GameObject current = Instantiate(ball, spawnpoint, Quaternion.identity);

                        current.GetComponent<Rigidbody>().AddForce((((transform.forward) + (transform.up * -1)) * multi * speed) * -1);
                        current.GetComponent<DestroyOnHit>().whoShotThis = whichPlayer;
                        rangePlane.GetComponent<rangePlaneStretcher>().Shot();

                    }
                    firing = false;
                }
            }
        }
            fakeBall.transform.position = Vector3.MoveTowards(fakeBall.transform.position, target.transform.position, 100 * Time.deltaTime);
    }
    
}


