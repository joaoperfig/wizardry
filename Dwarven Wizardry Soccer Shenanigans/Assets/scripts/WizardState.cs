using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardState {

	public bool allowsmovement;

	public bool allowsabilities;

	public Wizard wiz;

	public float speedmodifier=1;

	public bool allowswap;

	public WizardState(Wizard w) {
		wiz = w;
		allowswap = true;
	}
		
	public virtual void Update() {}
}
