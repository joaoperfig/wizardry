using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWizardState : WizardState {

	public NormalWizardState(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;
	}


}
