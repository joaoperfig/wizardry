using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrat {

	public float friendlyteam;
	public Wizard wiz;
	public AIStrategyController gc;
	public Vector3 myGoalPos; // defend this one
	public Vector3 enemyGoalPos; // attack thisone
	public Vector2 attackDirection;
	public Vector2 defendDirection;

	public AIStrat (Wizard w, AIStrategyController c) {
		wiz = w;
		gc = c;
		friendlyteam = w.teamtag;
		if (friendlyteam == 1) {
			myGoalPos = GameObject.Find ("LeftGoal").transform.position;
			enemyGoalPos = GameObject.Find ("RightGoal").transform.position;
			attackDirection = new Vector3 (1, 0, 0);
			defendDirection = new Vector3 (-1, 0, 0);
		} else {
			myGoalPos = GameObject.Find ("RightGoal").transform.position;
			enemyGoalPos = GameObject.Find ("LeftGoal").transform.position;
			attackDirection = new Vector2 (-1, 0);
			defendDirection = new Vector2 (1, 0);
		}
	}

	public virtual float negativeHeuristic(){
		return 999999;
	}

	public GameObject getBall(){
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		GameObject ball = balls [0];
		foreach (GameObject b in balls) {
			if ((wiz.gameObject.transform.position - b.transform.position).sqrMagnitude <= (wiz.gameObject.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}
		return ball;
	}

	public virtual void control(){
		
	}
}
