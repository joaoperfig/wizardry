using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStrategy : AIStrat {

	public Ability ability;
	public int button;

	public AbilityStrategy (Wizard w, AIStrategyController c, Ability a, int buttonid) : base(w, c){
		ability = a;
		button = buttonid;
	}

	public override float negativeHeuristic(){
		return 9999;
	}
		

	public override void control(){
	}

	public void activate (){
		switch (button) {
		case 1:
			gc.b1 ();
			break;
		case 2:
			gc.b2 ();
			break;
		case 3:
			gc.b3 ();
			break;
		case 4:
			gc.b4 ();
			break;
		default:
			Debug.Log ("UNKNOWN BUTTON PRESSED: " + button.ToString ());
			break;
		}
	}
}
