using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBall : Ability {

	public GameObject forceball;

	public ForceBall(Wizard w) : base(w){
		cooldown = 8f;
		castduration = 1f;
		forceball = (GameObject)Resources.Load ("force_ball");
		logo = findlogo("ability_icons_1_17");
	}

	public override void magic() {
		float distance = 0.2f;
		GameObject f = GameObject.Instantiate (forceball, wiz.transform.position + distance* new Vector3(wiz.lastdir.normalized.x, wiz.lastdir.normalized.y, 0), Quaternion.identity);
		force_ball df = f.GetComponent<force_ball> ();
		df.direction = wiz.lastdir.normalized;
		float rotat = Mathf.Atan2 (df.direction.x, df.direction.y) * Mathf.Rad2Deg;
		f.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );
	}
}
