using UnityEngine;
using System.Collections;

public class AILineOfSight : MonoBehaviour {
    public GameObject Player;
    public bool seesPlayer;
    public float fieldOfViewAngle = 110f;
    private SphereCollider sphereCol;
    // Use this for initialization
    void Awake () {
        sphereCol = GetComponent<SphereCollider>();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            Debug.Log("can't see you");
            if(seesPlayer) 
                Debug.Log("i see you");
            
        }
    void OnTriggerStay(Collider col) {
        if(col.gameObject.tag == "Player") {
            seesPlayer = false;
            Vector3 direction = col.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f) {
                RaycastHit hit;

                if(Physics.Raycast(transform.position /*+ transform.up*/, direction.normalized, out hit, sphereCol.radius)) {
                    if(hit.collider.gameObject.tag == "Player") {
                        //Debug.Log("hi");
                        seesPlayer = true;
                    }
                }
            }
        }
    }
}

