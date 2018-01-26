using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStratAttack : AIStrat {

	private float directionweight = 6f;
	private float positionweight = 2f;
	private float walkaround = 0.7f;
	private float tolerance = 0.2f;


	public AIStratAttack (Wizard w, AIStrategyController c) : base(w, c){
	}

	public override float negativeHeuristic(){
		GameObject b = getBall ();
		float dotgoal = -Vector2.Dot (b.GetComponent<Rigidbody2D> ().velocity, attackDirection); // this is -1 if ball is headed to enemy goal, 1 if to own goal
		float dotpos = -b.transform.position.x/enemyGoalPos.x; // -1 if ball realy close to enemy goal, 1 if ball is near own
		float heuristic = directionweight*dotgoal + positionweight*dotpos;
		return heuristic - 0.5f; // incentive to start on attack mode
	}
		
	public bool isbehind(){
		GameObject b = getBall ();
		if (attackDirection.x > 0) {
			return (wiz.gameObject.transform.position.x < b.transform.position.x);
		} else {
			return (wiz.gameObject.transform.position.x > b.transform.position.x);
		}
	}

	public override void control(){
		//Debug.Log ("Attack");
		GameObject b = getBall ();

		if (isbehind ()) {
			if (wiz.transform.position.x < b.transform.position.x - tolerance)
				gc.latentright ();
			if (wiz.transform.position.x > b.transform.position.x + tolerance)
				gc.latentleft ();
			if (wiz.transform.position.y < b.transform.position.y - tolerance)
				gc.latentup ();
			if (wiz.transform.position.y > b.transform.position.y + tolerance)
				gc.latentdown ();
		} else {  // Walk around ball
			//Debug.Log ("Attack - Walk Around");
			if ((wiz.gameObject.transform.position.y > b.transform.position.y+walkaround) || (wiz.gameObject.transform.position.y < b.transform.position.y-walkaround)) {
				if (defendDirection.x < 0) {
					gc.latentleft (); //needs to get ahead of ball; can do it without pushing
				} else {
					gc.latentright ();  //needs to get ahead of ball; can do it without pushing
				}
			}/*
			if (wiz.gameObject.transform.position.y > b.transform.position.y + (walkaround+tolerance)) {
				gc.down ();  //can walk down without pushing ball to go around it;
			}
			if (wiz.gameObject.transform.position.y < b.transform.position.y - (walkaround+tolerance)) {
				gc.up ();    //can walk up without pushing ball to go around it;
			}*/
			if (Mathf.Abs (wiz.gameObject.transform.position.y - b.transform.position.y) < walkaround) {
				if (myGoalPos.y > b.transform.position.y) {
					gc.latentup (); // needs to walk up and over the ball;
				} else {
					gc.latentdown (); // needs to walk down and uner the ball;
				}
			}
			if (Mathf.Abs (wiz.gameObject.transform.position.x - b.transform.position.x) > walkaround) {
				if (wiz.gameObject.transform.position.x > b.transform.position.x) {
					gc.latentleft (); // is far enough to walk towards ball without colliding;
				} else {
					gc.latentright (); // is far enough to walk towards ball without colliding;
				}
			}


		}


	}
}
