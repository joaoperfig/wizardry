using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : Ability {

	public GameObject tent;

	public Tentacle (Wizard w) : base(w){
		cooldown = 6f;
		castduration = 0.7f;
		tent = (GameObject)Resources.Load ("warlock_tentacle");
		logo = findlogo("abilty_icons_tentacle_4");
	}

	public override void magic() {
		GameObject t = GameObject.Instantiate (tent, wiz.transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.identity);
		warlock_tentacle wt = t.GetComponent<warlock_tentacle> ();
		wt.direction = wiz.lastdir.normalized;
		float rotat = Mathf.Atan2 (wt.direction.x, wt.direction.y) * Mathf.Rad2Deg;
		t.transform.rotation = Quaternion.Euler (0f, 0f, 180-rotat );
	}
}

