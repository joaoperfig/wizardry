using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warlock_tentacle : MonoBehaviour {

	public Vector2 direction;
	public float distance;
	public float force;
	public float inactive_time;

	public float duration;
	public float destroytime;
	private float starttime;

	private GameObject ball;

	private bool activated = false;
	public bool finished = false;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated && !finished) {
			Animator anim = gameObject.GetComponent<Animator> ();
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("thrown")) {
				ball.GetComponent<Ball> ().state = new NormalBallState (ball.GetComponent<Ball> ());
				Vector3 delta = new Vector3 ((direction * distance).x, (direction * distance).y, 0);
				ball.transform.position = gameObject.transform.position + delta;
				ball.GetComponent<Rigidbody2D> ().velocity = direction * force;
				finished = true;
			}
		}
		if (Time.time > (starttime + duration)) {
			if (!(finished)) {
				Animator anim = gameObject.GetComponent<Animator> ();
				anim.SetTrigger ("end");
				activated = true;
			}

		}
		if (Time.time > (starttime + duration+destroytime)) {
			Destroy (gameObject);

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ball") {
			if (!(activated) && (Time.time> starttime+inactive_time)) {
				Animator anim = gameObject.GetComponent<Animator> ();

				anim.SetTrigger ("catch");

				other.gameObject.GetComponent<Ball> ().state = new CarriedBallState (other.gameObject.GetComponent<Ball> ());
				other.gameObject.transform.position = new Vector3 (99, 99, 0); //ensures that ball does not need to wait for next update do disappear;

				activated = true;

				Debug.Log ("caught");

				ball = other.gameObject;
			}

		}

	}
}
