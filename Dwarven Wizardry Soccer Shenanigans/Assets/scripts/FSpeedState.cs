using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSpeedState : WizardState {

	private GameObject flameeffect;
	private float effectdur = 4;
	private float starttime;

	public FSpeedState(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 2;

		starttime = Time.time;

		flameeffect = (GameObject)Resources.Load ("flame_speed");
		flameeffect = GameObject.Instantiate (flameeffect, wiz.gameObject.transform);
	}

	public override void Update() {
		if (Time.time >= starttime + effectdur) {
			MonoBehaviour.Destroy (flameeffect);
			wiz.state = new NormalWizardState (wiz);
		}
		
		
	}
}