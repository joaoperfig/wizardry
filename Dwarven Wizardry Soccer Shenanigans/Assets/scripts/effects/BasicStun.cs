using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStun : WizardEffect {


	private float effectdur = 0.2f;
	public float starttime;

	public BasicStun(Wizard w) : base(w) {
		allowsmovement = false;

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