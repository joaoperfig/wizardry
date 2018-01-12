using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTeleportState : WizardState {

	private float effectdur = 0.3f;
	private float starttime;
	private teleport_rune rune;

	public RuneTeleportState(Wizard w, teleport_rune r) : base(w) {
		allowsmovement = false;

		allowsabilities = false;

		starttime = Time.time;

		rune = r;

	}

	public override void Update() {
		wiz.gameObject.transform.position = rune.gameObject.transform.position;
		if (Time.time >= starttime + effectdur) {
			wiz.state = new NormalWizardState (wiz);
		}


	}
}