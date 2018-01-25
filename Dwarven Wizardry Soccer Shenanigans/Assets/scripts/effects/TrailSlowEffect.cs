using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSlowEffect : WizardEffect{
	
	private float effectdur = 0.5f;
	public float starttime;

	public TrailSlowEffect(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 0.4f;

		starttime = Time.time;

	}

	public override void Update() {
		if (Time.time >= starttime + effectdur) {
			wiz.effects.Remove (this);
		}

	}
}