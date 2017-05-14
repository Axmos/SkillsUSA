using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingHill : MonoBehaviour {
    public List<GameObject> playersInCircle;
    public GameObject player1, player2, circle, crown;
    public Material red, blue, purple, gold;
    public GM myGM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playersInCircle.Contains(player1) && !playersInCircle.Contains(player2)) {
            circle.GetComponent<MeshRenderer>().material.color = blue.color;
            crown.GetComponent<SpriteRenderer>().material.color = blue.color;
            myGM.AddScore(Time.deltaTime, 1);
        } else if (!playersInCircle.Contains(player1) && playersInCircle.Contains(player2)) {
            circle.GetComponent<MeshRenderer>().material.color = red.color;
            crown.GetComponent<SpriteRenderer>().material.color = red.color;
            myGM.AddScore(Time.deltaTime, 2);
        } else if (playersInCircle.Contains(player1) && playersInCircle.Contains(player2)) {
            circle.GetComponent<MeshRenderer>().material.color = purple.color;
            crown.GetComponent<SpriteRenderer>().material.color = purple.color;
        } else {
            circle.GetComponent<MeshRenderer>().material.color = gold.color;
            crown.GetComponent<SpriteRenderer>().material.color = gold.color;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") == true) {
            playersInCircle.Remove(other.gameObject);
        }
    }
    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            GameObject go = other.gameObject;
            if (!playersInCircle.Contains(go)) {
                playersInCircle.Add(go);
            }
        }
    }
}
