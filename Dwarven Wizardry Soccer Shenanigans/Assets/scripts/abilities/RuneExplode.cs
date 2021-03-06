﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneExplode : Ability {

	public GameObject rune;

	public RuneExplode(Wizard w) : base(w){
		cooldown = 3.5f;
		castduration = 0.8f;
		rune = (GameObject)Resources.Load ("explode_rune");
		logo = findlogo("ability_icons_1_10");
	}

	public override void magic() {
		Vector2 rot = new Vector2 (1 - Random.value * 2, 1 - Random.value * 2);
		rot.Normalize ();
		float rotat = Mathf.Atan2 (rot.x, rot.y) * Mathf.Rad2Deg;
		GameObject.Instantiate (rune, wiz.transform.position + new Vector3(0f, -0.4f, 0f), Quaternion.Euler (0f, 0f, -rotat ));
	}
}