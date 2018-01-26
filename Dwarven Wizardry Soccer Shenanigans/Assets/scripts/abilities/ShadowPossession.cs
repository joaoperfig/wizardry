using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPossession : Ability {

	public GameObject smoke;

	private GameObject courier;

	public ShadowPossession(Wizard w) : base(w){
		cooldown = 9f;
		castduration = 0f;
		smoke = (GameObject)Resources.Load ("smoke_explosion");
		courier = (GameObject)Resources.Load ("possession_courier");
		logo = findlogo("abilty_icons_shadow_5");
	}

	public override void magic() {
		GameObject.Instantiate (smoke, wiz.transform.position, Quaternion.identity);

		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		GameObject ball = balls [0];
		foreach (GameObject b in balls) {
			if ((wiz.gameObject.transform.position - b.transform.position).sqrMagnitude <= (wiz.gameObject.transform.position - ball.transform.position).sqrMagnitude) {
				ball = b;
			}
		}
		if (ball.GetComponent<Ball> ().state.canreach) {
			GameObject cou = GameObject.Instantiate (courier, wiz.transform.position, Quaternion.identity);
			possession_courier sc = cou.GetComponent<possession_courier> ();
			sc.carrying = wiz;
			wiz.state = new CastIntoState (wiz, this, new CourriedWizardState (wiz));
		}
	}


}

