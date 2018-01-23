using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardEffect {

	public bool allowsabilities;
	public bool allowsmovement;
	public float speedmodifier = 1;

	public Wizard wiz;

	public WizardEffect(Wizard w){
		wiz = w;
	}

	public virtual void Update() {
	}
}
