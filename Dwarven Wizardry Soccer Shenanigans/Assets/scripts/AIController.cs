using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : GameController {
	public GameObject ball;
	public float actionRadius = 0.6f;

	public override void check() {
		ball = GameObject.FindGameObjectsWithTag("Ball")[0];
		if (ball.GetComponent<Ball>() == null) Debug.Log("No ball...");
		if (controledws[0].gameObject.transform.position.x - actionRadius > ball.transform.position.x) left();
		if (controledws[0].gameObject.transform.position.x + actionRadius < ball.transform.position.x) right();
		if (controledws[0].gameObject.transform.position.y - actionRadius > ball.transform.position.y) down();
		if (controledws[0].gameObject.transform.position.y + actionRadius < ball.transform.position.y) up();
		if ((controledws[0].gameObject.transform.position - ball.transform.position).magnitude < actionRadius) b1();				
	}
}
