using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour {
    public float multi, speed, d, bullshit;
    public GameObject indicator;
    public fire myFire;
	// Use this for initialization
	void Start () {
        myFire = GetComponentInChildren<fire>();
        speed = myFire.speed;
        multi = myFire.max - myFire.min ;
        multi *= bullshit;
        d = ((Mathf.Pow(multi * speed, 2f)) / Physics.gravity.y) * Mathf.Sin(90);//distance
        Vector3 indicPos = (((d / speed) * 1.3f) * transform.forward) + transform.position;
       
        indicator.transform.position = indicPos;
    }
	
	// Update is called once per frame
	void Update () {
       // Vector3 indicPos = (((d / speed) * 1.3f) * transform.forward) + transform.position;
       // indicPos.y = indicPos.y + 5f;
       // indicator.transform.position = indicPos;

        //code for indicator

    }
}
