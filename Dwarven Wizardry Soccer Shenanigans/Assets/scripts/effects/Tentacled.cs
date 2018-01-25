using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacled : WizardEffect {


	private float effectdur = 0.1f;
	public float starttime;

	public Tentacled(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 0f;

		starttime = Time.time;
	}

	public override void Update() {
		if (Time.time >= starttime + effectdur) {;
			wiz.effects.Remove (this);
		}

	}
}