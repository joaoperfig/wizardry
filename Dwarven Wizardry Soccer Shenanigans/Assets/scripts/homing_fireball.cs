using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_fireball : MonoBehaviour {

	private GameObject ball;
	private Rigidbody2D rbd;
	public float initialsp;
	public float speed;
	public float controlspeed;
	public float force;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		ball = balls [0];
		foreach (GameObject b in balls) {
			if ((gameObject.transform.position - b.transform.position).sqrMagnitude <= (gameObject.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}
		rbd = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 diff =  ball.transform.position - transform.position;
		diff.Normalize ();
		rbd.velocity = (diff * initialsp);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff =  ball.transform.position - transform.position;
		diff.Normalize ();
		float rotat = Mathf.Atan2 (diff.x, diff.y) * Mathf.Rad2Deg;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );

	}

	void FixedUpdate() {
		Vector2 diff =  ball.transform.position - transform.position;
		diff.Normalize ();
		rbd.AddForce (diff * speed*Time.fixedDeltaTime);
		Vector2 delta = diff * controlspeed * Time.fixedDeltaTime;
		transform.position = transform.position + new Vector3 (delta.x, delta.y, 0);
	}
		

	void test() {
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ball") {
			GameObject.Instantiate (explosion, this.transform.position , Quaternion.identity);
			Rigidbody2D orb = other.gameObject.GetComponent<Rigidbody2D> ();
			Vector2 diff = orb.gameObject.transform.position - gameObject.transform.position;
			orb.velocity = orb.velocity + diff * force;
			Destroy (gameObject);
		}

	}
}
