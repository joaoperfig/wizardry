using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTrail : Ability {

	public GameObject effect;
	public float force = 140;

	public TentacleTrail(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 0f;
		logo = findlogo("abilty_icons_tentacle_3");
	}

	public override void magic() {
		Rigidbody2D rbd = wiz.gameObject.GetComponent<Rigidbody2D> ();
		rbd.AddForce (force * wiz.lastdir);
		wiz.effects.Add (new LeaveTrailEffect (wiz));
	}
}