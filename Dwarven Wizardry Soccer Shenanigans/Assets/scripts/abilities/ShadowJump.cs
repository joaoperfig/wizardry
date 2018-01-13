using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowJump : Ability {

	public GameObject smoke;

	private GameObject courier;

	public ShadowJump(Wizard w) : base(w){
		cooldown = 3f;
		castduration = 0f;
		smoke = (GameObject)Resources.Load ("smoke_explosion");
		courier = (GameObject)Resources.Load ("smoke_courier");
		logo = findlogo("abilty_icons_shadow_3");
	}

	public override void magic() {
		GameObject.Instantiate (smoke, wiz.transform.position, Quaternion.identity);
		GameObject cou = GameObject.Instantiate (courier, wiz.transform.position, Quaternion.identity);
		smoke_courier sc = cou.GetComponent<smoke_courier> ();
		sc.direction = wiz.lastdir.normalized;
		sc.carrying = wiz;
		wiz.state = new CastIntoState (wiz, this, new CourriedWizardState (wiz));
	}


}


