using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possession_courier : MonoBehaviour {
	
	public Wizard carrying;

	private GameObject circle;
	private GameObject ball;
	public float speed;

	private GameObject smoke;

	// Use this for initialization
	void Start () {
		smoke = (GameObject)Resources.Load ("smoke_explosion");
		circle = (GameObject)Resources.Load ("possession_circle");

		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		ball = balls [0];
		foreach (GameObject b in balls) {
			if ((gameObject.transform.position - b.transform.position).sqrMagnitude <= (gameObject.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}


	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		Vector2 diff =  ball.transform.position - transform.position;
		diff.Normalize ();
		Vector2 delta = diff * speed * Time.fixedDeltaTime;
		transform.position = transform.position + new Vector3 (delta.x, delta.y, 0);
	}


	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ball") {
			GameObject.Instantiate (smoke, this.transform.position , Quaternion.identity);

			GameObject circ = GameObject.Instantiate (circle, ball.transform.position , Quaternion.identity);
			GameObject ent = circ.transform.GetChild (0).gameObject;
			possession_entity entity = ent.GetComponent<possession_entity> ();

			entity.ball = ball;
			entity.carried = carrying;

			Destroy (gameObject);
		}

	}
		
}