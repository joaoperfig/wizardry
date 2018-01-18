using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : GameController {
	public GameObject ball;
	public float actionRadius = 0.6f;
	public float timeToRandomAb = 3;

	private float last = Time.time;
	private float wait = 5;

	public override void check() {
		ball = GameObject.FindGameObjectsWithTag("Ball")[0];
		if (ball.GetComponent<Ball>() == null) Debug.Log("No ball...");
		if (controledws[0].gameObject.transform.position.x - actionRadius > ball.transform.position.x) left();
		if (controledws[0].gameObject.transform.position.x + actionRadius < ball.transform.position.x) right();
		if (controledws[0].gameObject.transform.position.y - actionRadius > ball.transform.position.y) down();
		if (controledws[0].gameObject.transform.position.y + actionRadius < ball.transform.position.y) up();
		if ((controledws[0].gameObject.transform.position - ball.transform.position).magnitude < actionRadius) b1();	

		if (Time.time > (last + wait)) {
			switch (Random.Range (1, 4)) {
			case 1:
				b2 ();
				break;
			case 2:
				b3 ();
				break;
			case 3:
				b4 ();
				break;
			default:
				b1 ();
				break;

			}
			wait = timeToRandomAb * (1 + Random.value);
			last = Time.time;
		}

	}
}
