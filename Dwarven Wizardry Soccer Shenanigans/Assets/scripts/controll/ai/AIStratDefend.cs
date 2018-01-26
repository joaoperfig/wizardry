using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStratDefend : AIStrat {

	private float directionweight = 6f;
	private float positionweight = 2f;
	private float walkaround = 0.7f;
	private float tolerance = 0.25f;
	private float safedistance = 3f;
	private float minbalveltopred = .5f;

	public AIStratDefend (Wizard w, AIStrategyController c) : base(w, c){
	}

	public override float negativeHeuristic(){
		GameObject b = getBall ();
		if (!b.GetComponent<Ball> ().state.canreach)
			return -9999; // goes to defend position if there is no ball;
		float dotgoal = Vector2.Dot (b.GetComponent<Rigidbody2D> ().velocity, attackDirection); // this is -1 if ball is headed to own goal, 1 if to enemy goal
		float dotpos = b.transform.position.x/enemyGoalPos.x; // -1 if ball realy close to own goal, 1 if ball is near enemy
		float heuristic = directionweight*dotgoal + positionweight*dotpos;
		return heuristic;
	}

	private bool isblocking(){
		GameObject b = getBall ();
		if (attackDirection.x > 0) {
			return (wiz.gameObject.transform.position.x < b.transform.position.x); //- walkaround);
		} else {
			return (wiz.gameObject.transform.position.x > b.transform.position.x); // + walkaround);
		}
	}

	private float yintersect(){
		GameObject b = getBall ();
		Vector3 bpos = b.transform.position;
		Vector3 wpos = wiz.gameObject.transform.position;
		Vector2 bdir = b.GetComponent<Rigidbody2D> ().velocity;
		if ((bdir.x == 0) || (Vector2.Dot(defendDirection, bdir)<0) || (bdir.magnitude < minbalveltopred)) {
			return bpos.y;
		}
		float intersect = bpos.y + bdir.y * ((wpos.x - bpos.x) / bdir.x);
		return intersect;

	}

	public override void control(){
		//Debug.Log ("Defend");
		GameObject b = getBall ();

		if (!b.GetComponent<Ball> ().state.canreach) {  // go to front of goal
			Vector3 dest = myGoalPos + 2*(new Vector3(attackDirection.x, attackDirection.y, 0));
			if (wiz.transform.position.x < dest.x - tolerance)
				gc.latentright ();
			if (wiz.transform.position.x > dest.x + tolerance)
				gc.latentleft ();
			if (wiz.transform.position.y < dest.y - tolerance)
				gc.latentup ();
			if (wiz.transform.position.y > dest.y + tolerance)
				gc.latentdown ();
		}

		if (isblocking ()) {
			if (wiz.gameObject.transform.position.y > yintersect()+tolerance) {
				gc.latentdown (); // far from ball and over it
			}
			if (wiz.gameObject.transform.position.y < yintersect ()-tolerance) {
				gc.latentup (); // far from ball and under it
			}
			if ((wiz.gameObject.transform.position.y > yintersect ()) && (Mathf.Abs (wiz.gameObject.transform.position.x - b.transform.position.x) < safedistance)) {
				gc.latentdown (); // near ball and over it
			}
			if ((wiz.gameObject.transform.position.y < yintersect ()) && (Mathf.Abs (wiz.gameObject.transform.position.x - b.transform.position.x) < safedistance)) {
				gc.latentup (); // near ball and under it
			}
		} else { // Walk around ball
			//Debug.Log ("Defent - Walk Around");
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
