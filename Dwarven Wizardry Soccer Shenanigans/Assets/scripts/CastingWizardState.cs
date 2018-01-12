using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingWizardState : WizardState {

	private Ability ab;
	private WizardState returnstate;

	public CastingWizardState(Wizard w, Ability a, WizardState ret) : base(w) {
		allowsmovement = false;

		allowsabilities = false;

		ab = a;

		returnstate = ret;
	}

	public override void Update() {
		if (ab.canUncast ()) {
			wiz.uncastAnimation ();
			wiz.state = returnstate;
		}
	}
}
