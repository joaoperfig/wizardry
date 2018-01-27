using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSkeleton : Ability {

	public GameObject skeleton;

	public DeathSkeleton(Wizard w) : base(w){
		cooldown = 7f;
		castduration = 0.8f;
		skeleton = (GameObject)Resources.Load ("skeleton");
		logo = findlogo("abilty_icons_death_5");
	}

	public override void magic() {
		Vector3 delta = new Vector3 (wiz.lastdir.x, wiz.lastdir.y, 0)*0.5f;
		GameObject s = GameObject.Instantiate (skeleton, wiz.transform.position + delta , Quaternion.identity);
		s.GetComponent<skeleton> ().friendlyteam = wiz.teamtag;
	}
}
