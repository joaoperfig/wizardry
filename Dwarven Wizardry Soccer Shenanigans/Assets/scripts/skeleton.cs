using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour {

	public float friendlyteam;
	public float speed;
	public float duration;

	private float starttime;
	// Use this for initialization
	void Start () {
		starttime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Rigidbody2D> ().angularVelocity = 0;
		gameObject.transform.rotation = Quaternion.identity;

		if (Time.time > starttime + duration)gameObject.GetComponent<Animator> ().SetTrigger ("die");
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("dead")) return;
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("destroyed")) Destroy(gameObject);
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("start")) return;

		GameObject ball = null;
		Rigidbody2D rbd;
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		ball = balls [0];
		foreach (GameObject b in balls) {
			if ((gameObject.transform.position - b.transform.position).sqrMagnitude <= (gameObject.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}
		rbd = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 diff = ball.transform.position - gameObject.transform.position;
		diff.Normalize ();
		rbd.velocity = (diff * speed);
	}
}
