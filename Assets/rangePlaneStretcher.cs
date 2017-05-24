using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangePlaneStretcher : MonoBehaviour {
    public float intSpeed, speed;
    
    Vector3 temp = new Vector3(0, 0, 0);
    
    
	// Use this for initialization
	void Start () {
        temp = transform.localScale;
        speed = intSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        temp.z += Time.deltaTime * speed;
        transform.localScale = temp;
	}
    
    public void Shot() {
        temp.z = 0.01f;
        transform.localScale = temp;
        gameObject.SetActive(false);
    }
    private void OnEnable() {
        speed = intSpeed;
        GetComponent<BoxCollider>().enabled = true;
    }
}
