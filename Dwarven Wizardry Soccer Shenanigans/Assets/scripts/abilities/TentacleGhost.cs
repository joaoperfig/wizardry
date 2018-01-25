using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleGhost : Ability {

	public GameObject tentacle;

	public TentacleGhost(Wizard w) : base(w){
		cooldown = 6f;
		castduration = 1f;
		tentacle = (GameObject)Resources.Load ("warlock_ballpush");
		logo = findlogo("abilty_icons_tentacle_5");
	}

	public override void magic() {
		GameObject instance = GameObject.Instantiate (tentacle, wiz.gameObject.transform.position, Quaternion.identity);
		instance.GetComponent<tentacle_push> ().friendlyteam = wiz.teamtag;
	}
}
