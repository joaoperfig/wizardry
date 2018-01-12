using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastIntoState : WizardState {

	private Ability ab;
	private WizardState nextstate;

	public CastIntoState(Wizard w, Ability a, WizardState s) : base(w) {
		allowsmovement = false;

		allowsabilities = false;

		nextstate = s;

		ab = a;
	}

	public override void Update() {
		if (ab.canUncast ()) {
			wiz.uncastAnimation ();
			wiz.state = nextstate;
		}
	}
}
