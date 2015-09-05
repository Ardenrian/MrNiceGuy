using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	public GameObject preceding;
	private float distance;
	public float speed;
	private Rigidbody rbz;
	public float speedup;
	private SphereCollider rbzpreceding;

	// Use this for initialization
	void Start () {
		distance = Vector3.Distance (preceding.transform.position, transform.position);
		rbz = GetComponent<Rigidbody> ();
		rbzpreceding = preceding.GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (preceding.transform.position, transform.position) > 1) {
			Vector3 direction= preceding.transform.position- transform.position;
			rbz.AddForce(Time.deltaTime*direction* (speed + speedup*Time.time));
		}

		//try to do an OK pathfinder... as in, go around stuff. so not a pathfinder at all, just something that doesnt collide with walls and stuff.
		//Vector3 positionpreceding = preceding.transform.position + Time.deltaTime * rbzpreceding.velocity;
		//float distance= Vector3.Distance (preceding.transform.position, transform.position);
		//Vector3 direction= preceding.transform.position- transform.position;
		//bool obstacle = Physics.Raycast (transform.position, direction, distance/2);
		//if (!obstacle) {
		////	rbz.AddForce (Time.deltaTime * direction * (speed + speedup * Time.time));
		//} else {
		//	rbz.AddForce(Time.deltaTime * rbzpreceding.velocity * (speed + speedup * Time.time));
	//	}
	}
}
