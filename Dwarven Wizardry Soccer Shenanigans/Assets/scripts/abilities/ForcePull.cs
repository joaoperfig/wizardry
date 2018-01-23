using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePull : Ability {

	public GameObject effect;
	public GameObject ball;
	public float force = 60;

	public ForcePull(Wizard w) : base(w){
		cooldown = 5f;
		castduration = 0.5f;
		effect = (GameObject)Resources.Load ("force_attraction");
		logo = findlogo("ability_icons_1_16");

	}

	public override void magic() {

		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		ball = balls [0];
		foreach (GameObject b in balls) {
			if ((wiz.transform.position - b.transform.position).sqrMagnitude <= (wiz.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}

		GameObject instance = GameObject.Instantiate (effect, wiz.transform.position, Quaternion.identity);
		fpull_effect ff = instance.GetComponent<fpull_effect> ();
		ff.follow = wiz.gameObject;
		ff.pointto = ball;
		ff.duration = 0.6f;

		instance = GameObject.Instantiate (effect, wiz.transform.position, Quaternion.identity);
		ff = instance.GetComponent<fpull_effect> ();
		ff.follow = ball;
		ff.pointto = wiz.gameObject;
		ff.duration = 0.6f;

		Vector2 delta = wiz.gameObject.transform.position - ball.transform.position;
		Rigidbody2D rbd = ball.GetComponent<Rigidbody2D> ();
		rbd.AddForce (force * delta.normalized);
	}
}