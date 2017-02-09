using UnityEngine;
using System.Collections;

public class walking : MonoBehaviour {
	public float horizonal;
	public float speed = 1;
	public float jump;
	public bool grounded;
	public float baseGravity, gravityScaling;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horizonal = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;

		//move 
		GetComponent<Transform> ().Translate (horizonal, 0f, 0f);
		if (grounded) {
			GetComponent<Rigidbody2D> ().gravityScale = baseGravity;
			if (Input.GetAxisRaw ("Vertical") > .5f) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jump));
				grounded = false;
			}
		}
		if (GetComponent<Rigidbody2D> ().velocity.y < -.1) {
			GetComponent<Rigidbody2D> ().gravityScale = baseGravity * gravityScaling;
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
			grounded = true;
	}
}
