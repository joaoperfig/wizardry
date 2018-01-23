using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastIntoEffect : WizardState {

	private Ability ab;
	private WizardEffect effect;
	private WizardState retrn;

	public CastIntoEffect(Wizard w, Ability a, WizardEffect e, WizardState ret) : base(w) {
		allowsmovement = false;

		allowsabilities = false;

		effect = e;

		ab = a;

		retrn = ret;
	}

	public override void Update() {
		if (ab.canUncast ()) {
			wiz.uncastAnimation ();
			wiz.state = retrn;
			wiz.effects.Add (effect);
		}
	}
}