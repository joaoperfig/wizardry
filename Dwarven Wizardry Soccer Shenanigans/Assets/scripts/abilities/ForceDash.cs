using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDash : Ability {

	public GameObject effect;
	public float force = 200;

	public ForceDash(Wizard w) : base(w){
		cooldown = 3f;
		castduration = 0f;
		effect = (GameObject)Resources.Load ("force_dash");
		logo = findlogo("ability_icons_1_15");
	}

	public override void magic() {
		GameObject instance = GameObject.Instantiate (effect, wiz.transform.position, Quaternion.identity);
		fdash_effect ff = instance.GetComponent<fdash_effect> ();
		ff.follow = wiz.gameObject;
		ff.direction = -wiz.lastdir;
		Rigidbody2D rbd = wiz.gameObject.GetComponent<Rigidbody2D> ();
		rbd.AddForce (force * wiz.lastdir);
	}
}