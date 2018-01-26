using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASRandom : AbilityStrategy {

	public float usespersecond = 0.1f; 

	public ASRandom (Wizard w, AIStrategyController c, Ability a, int buttonid) : base(w, c, a, buttonid){

	}

	public override float negativeHeuristic(){
		if (ability.waittime () > 0) {
			return 999;
		}
		if (Random.Range (0, 1 / (usespersecond * Time.deltaTime)) < 1f) {
			return -998;
		}
		return 999;

	}

	public override void control(){
		switch (Random.Range (0, 3)) {
		case 0:
			gc.up ();
			break;
		case 1:
			gc.up ();
			if (attackDirection.x > 0) gc.right (); else gc.left ();
			break;
		case 2:
			if (attackDirection.x > 0) gc.right (); else gc.left ();
			break;
		case 3:
			if (attackDirection.x > 0) gc.right (); else gc.left ();
			break;
		case 4:
			gc.down ();
			if (attackDirection.x > 0) gc.right (); else gc.left ();
			break;
		case 5:
			gc.down ();
			break;
		default:
			if (attackDirection.x > 0) gc.right (); else gc.left ();
			break;
		}
		activate ();
	}
}
