using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentacle_push : MonoBehaviour {

	public GameObject ball;

	public int friendlyteam;

	public float rotSpeed;

	public float force;

	public float duration;

	private float starttime;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
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
		if (Time.time > starttime + duration) {
			gameObject.GetComponent<Animator> ().SetTrigger ("end");
			gameObject.transform.GetChild(0).gameObject.GetComponent<Animator> ().SetTrigger ("end");
		}
		gameObject.transform.position = ball.transform.position;
		gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), rotSpeed * Time.deltaTime);
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Wizard") {
			if (other.gameObject.GetComponent<Wizard> ().teamtag != friendlyteam) {
				Rigidbody2D orb = other.gameObject.GetComponent<Rigidbody2D> ();
				Vector2 diff = orb.gameObject.transform.position - gameObject.transform.position;
				orb.velocity = orb.velocity + diff * force;
				other.gameObject.GetComponent<Wizard> ().effects.Add (new Tentacled (other.gameObject.GetComponent<Wizard> ()));
			}
		}

	}
}
