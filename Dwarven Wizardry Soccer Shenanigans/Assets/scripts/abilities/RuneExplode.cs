using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneExplode : Ability {

	public GameObject rune;

	public RuneExplode(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 1f;
		rune = (GameObject)Resources.Load ("explode_rune");
	}

	public override void magic() {
		Vector2 rot = new Vector2 (1 - Random.value * 2, 1 - Random.value * 2);
		rot.Normalize ();
		float rotat = Mathf.Atan2 (rot.x, rot.y) * Mathf.Rad2Deg;
		GameObject.Instantiate (rune, wiz.transform.position + new Vector3(0f, -0.15f, 0f), Quaternion.Euler (0f, 0f, -rotat ));
	}
}