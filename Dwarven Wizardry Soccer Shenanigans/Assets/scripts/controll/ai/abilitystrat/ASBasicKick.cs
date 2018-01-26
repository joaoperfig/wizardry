using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASBasicKick : AbilityStrategy {

	public float minimdist = 0.9f;
	public float dangerzone = 0.6f;

	public float dangeraccuracy = 0.3f;
	public float accuracy = -0.5f; // -1 if will only kick when PRECISELY LINED UP;  1 Will kick whennever in range

	public ASBasicKick (Wizard w, AIStrategyController c, Ability a, int buttonid) : base(w, c, a, buttonid){
		
	}

	public override float negativeHeuristic(){
		if (ability.waittime () > 0) {
			return 999;
		}
		GameObject b = getBall ();
		if ((wiz.gameObject.transform.position - b.transform.position).magnitude > minimdist) {
			return 999;
		}
		Vector3 toball = (b.transform.position - wiz.gameObject.transform.position).normalized;
		Vector3 togoal = (enemyGoalPos - wiz.gameObject.transform.position).normalized;
		float dotpos = -b.transform.position.x/enemyGoalPos.x; // -1 if ball realy close to enemy goal, 1 if ball is near own
		float dotdir = -Vector3.Dot(toball, togoal); // -1 if ball will go to goal
		if (dotpos > dangerzone) { // is very close to own goal
			if (dotdir < dangeraccuracy) {
				return -999; // this ability will be chosen
			}
		} else {
			if (dotdir < accuracy) {
				return -999; // this ability will be chosen
			}
		}
		return 999;
	}

	public override void control(){
		activate ();
	}
}
