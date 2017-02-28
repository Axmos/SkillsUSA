using UnityEngine;
using System.Collections;

public class AILineOfSight : MonoBehaviour {
    public GameObject Player, GameManager;
    public bool seesPlayer;
    public float fieldOfViewAngle = 110f; //angle that guard can see in front of them
    private SphereCollider sphereCol;
    public float speed, alarmRange , rotateSpeed, attackRange;
	public Vector3 lastSeenPosition;
	public NavMeshAgent navMeshAgent;
    // Use this for initialization
    void Awake () {
        sphereCol = GetComponent<SphereCollider>(); //gets the sphere trigger around guard
		navMeshAgent = GetComponent<NavMeshAgent>(); //gets the navmeshagent
    }
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
		navMeshAgent.speed = speed;
        if (seesPlayer) {
			lastSeenPosition = FindClosestWithTag ("Player").transform.position; //sets a reminder of where he was seen last.
			if (GameManager.GetComponent<GameManager> ().alarmOn) {
                if (Vector3.Distance(transform.position, FindClosestWithTag("Player").transform.position) < attackRange) {
                    Debug.Log("Got you");
					Vector3 target = FindClosestWithTag ("Player").transform.position;
					target.y = transform.position.y;
					transform.LookAt (target);
                } else {
					Vector3 target = FindClosestWithTag ("Player").transform.position;
					//float step = speed * Time.deltaTime;
					//transform.position = Vector3.MoveTowards(transform.position, FindClosestWithTag("Player").transform.position, step);
					target.y = transform.position.y;
					transform.LookAt (target);
					navMeshAgent.destination = target;
                }
            } else {
				InvokeRepeating("GoToAlarm", 0f, 0.01f);
            }
            //Debug.Log("i see you");
            } else {
                Debug.Log("can't see you");
            }
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
    GameObject FindClosestWithTag(string tag) {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
	void GoToAlarm () {
		if (Vector3.Distance(transform.position, FindClosestWithTag("Alarm").transform.position) < alarmRange) {
			Debug.Log("ALARM ALARM ALARM");
			GameManager.GetComponent<GameManager> ().alarmOn = true;
			CancelInvoke("GoToAlarm");
			//float step = speed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, lastSeenPosition, step);
			navMeshAgent.destination = lastSeenPosition;
			lastSeenPosition.y = transform.position.y;
			transform.LookAt (lastSeenPosition);
		} else {
			Vector3 target = FindClosestWithTag ("Alarm").transform.position;
			//float step = speed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, FindClosestWithTag("Alarm").transform.position, step);

			navMeshAgent.destination = target;
			target.y = transform.position.y;
			transform.LookAt (target);
		}
}
}

