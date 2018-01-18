using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourriedWizardState : WizardState {

	private WizardState returnstate;

	public CourriedWizardState(Wizard w) : base(w) {
		allowsmovement = false;

		allowsabilities = false;

		allowswap = false;
	}

	public override void Update() {
		wiz.gameObject.transform.position = new Vector3 (99, 99, 99);
	}
}
