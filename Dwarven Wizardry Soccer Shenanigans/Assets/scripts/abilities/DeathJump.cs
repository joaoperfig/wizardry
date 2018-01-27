using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathJump : Ability {

	public GameObject smoke;

	private GameObject courier;

	private GameObject skeleton;

	public DeathJump(Wizard w) : base(w){
		cooldown = 6f;
		castduration = 0f;
		courier = (GameObject)Resources.Load ("death_courier");
		skeleton = (GameObject)Resources.Load ("death_jump");
		logo = findlogo("abilty_icons_death_3");
	}

	public override void magic() {
		GameObject skel = GameObject.Instantiate (skeleton, wiz.transform.position, Quaternion.identity);
		skel.GetComponent<death_jump> ().died = wiz;

		GameObject cou = GameObject.Instantiate (courier, wiz.transform.position, Quaternion.identity);
		death_courier dc = cou.GetComponent<death_courier> ();
		dc.direction = wiz.lastdir.normalized;
		dc.carrying = wiz;
		float rotat = Mathf.Atan2 (dc.direction.x, dc.direction.y) * Mathf.Rad2Deg;
		cou.transform.rotation = Quaternion.Euler (0f, 0f, 90-rotat );
		wiz.state = new CastIntoState (wiz, this, new CourriedWizardState (wiz));
	}


}


