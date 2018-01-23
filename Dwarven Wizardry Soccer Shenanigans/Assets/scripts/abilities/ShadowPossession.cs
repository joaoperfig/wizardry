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
		GameObject cou = GameObject.Instantiate (courier, wiz.transform.position, Quaternion.identity);
		possession_courier sc = cou.GetComponent<possession_courier> ();
		sc.carrying = wiz;
		wiz.state = new CastIntoState (wiz, this, new CourriedWizardState (wiz));
	}


}

