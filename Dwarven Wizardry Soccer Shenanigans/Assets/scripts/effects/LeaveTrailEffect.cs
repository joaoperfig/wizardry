using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrailEffect : WizardEffect {

	private GameObject puddle;
	private float effectdur = 0.6f;
	private float starttime;

	public float timetonext = 0.05f;
	private float lasttime;

	public LeaveTrailEffect(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 1.6f;

		starttime = Time.time;

		puddle = (GameObject)Resources.Load ("warlock_trail");

		makePuddle ();	
	}

	public override void Update() {
		if (Time.time >= lasttime + timetonext) {
			makePuddle ();
		}
		if (Time.time >= starttime + effectdur) {
			wiz.effects.Remove (this);
		}

	}

	public void makePuddle(){
		Vector2 rot = new Vector2 (1 - Random.value * 2, 1 - Random.value * 2);
		rot.Normalize ();
		float rotat = Mathf.Atan2 (rot.x, rot.y) * Mathf.Rad2Deg;
		GameObject pud = GameObject.Instantiate (puddle, wiz.gameObject.transform.position, Quaternion.Euler (0f, 0f, -rotat));
		pud.GetComponent<dark_trail> ().friendlyteam = wiz.teamtag;
		lasttime = Time.time;
	}

}