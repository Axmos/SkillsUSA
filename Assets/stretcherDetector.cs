using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretcherDetector : MonoBehaviour {
      
    private void OnTriggerEnter(Collider col) {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<rangePlaneStretcher>().speed = 0;
    }
}
