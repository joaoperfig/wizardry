using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardState {

	public bool allowsmovement;

	public bool allowsabilities;

	public Wizard wiz;

	public float speedmodifier=1;

	public WizardState(Wizard w) {
		wiz = w;
	}
		
	public virtual void Update() {}
}
