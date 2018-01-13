using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneImplode : Ability {

	public GameObject rune;

	public RuneImplode(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 1f;
		rune = (GameObject)Resources.Load ("implode_rune");
		logo = findlogo("ability_icons_1_11");
	}

	public override void magic() {
		Vector2 rot = new Vector2 (1 - Random.value * 2, 1 - Random.value * 2);
		rot.Normalize ();
		float rotat = Mathf.Atan2 (rot.x, rot.y) * Mathf.Rad2Deg;
		GameObject.Instantiate (rune, wiz.transform.position + new Vector3(0f, -0.4f, 0f), Quaternion.Euler (0f, 0f, -rotat ));
	}
}

