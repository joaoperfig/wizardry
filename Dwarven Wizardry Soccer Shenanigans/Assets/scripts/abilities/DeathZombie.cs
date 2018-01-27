using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZombie : Ability {

	public GameObject zombie;

	public DeathZombie(Wizard w) : base(w){
		cooldown = 9f;
		castduration = 1.5f;
		zombie = (GameObject)Resources.Load ("zombie");
		logo = findlogo("abilty_icons_death_4");
	}

	public override void magic() {
		Vector3 delta = new Vector3 (wiz.lastdir.x, wiz.lastdir.y, 0)*0.5f;
		GameObject z = GameObject.Instantiate (zombie, wiz.transform.position + delta , Quaternion.identity);
		z.GetComponent<zombie> ().friendlyteam = wiz.teamtag;
	}
}
