using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTeleport : Ability {

	public GameObject rune;

	private bool created = false;
	private teleport_rune current;

	public RuneTeleport(Wizard w) : base(w){
		cooldown = 5f;
		castduration = 0.5f;
		rune = (GameObject)Resources.Load ("teleport_rune");
		logo = findlogo("ability_icons_1_9");
	}

	public override void magic() {
		if (!(created)) {
			Vector2 rot = new Vector2 (1 - Random.value * 2, 1 - Random.value * 2);
			rot.Normalize ();
			float rotat = Mathf.Atan2 (rot.x, rot.y) * Mathf.Rad2Deg;
			GameObject f = GameObject.Instantiate (rune, wiz.transform.position + new Vector3 (0f, -0.4f, 0f), Quaternion.Euler (0f, 0f, -rotat));
			current = f.GetComponent<teleport_rune> ();
			created = true;
		} else {
			wiz.state = new CastIntoState(wiz, this, new RuneTeleportState (wiz, current));
			current.activate ();
			created = false;
		}
	}
}