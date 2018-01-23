using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneStunEffect : WizardEffect {

	private GameObject runeeffect;
	private float effectdur = 2f;
	public float starttime;

	public RuneStunEffect(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = false;

		speedmodifier = 0f;

		starttime = Time.time;

		runeeffect = (GameObject)Resources.Load ("rune_stun");
		runeeffect = GameObject.Instantiate (runeeffect, wiz.gameObject.transform);
	}

	public override void Update() {
		if (Time.time >= starttime + effectdur) {
			runeeffect.GetComponent<Animator> ().SetTrigger ("end");
			wiz.effects.Remove (this);
			Debug.Log ("REMOVE");
		}

	}
}