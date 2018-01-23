using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSpeedState : WizardState {  //REDACTED, SEE FPSPEEDEFFECT!!!!!

	private GameObject flameeffect; //REDACTED, SEE FPSPEEDEFFECT!!!!!
	private float effectdur = 4;
	private float starttime;

	public FSpeedState(Wizard w) : base(w) { //REDACTED, SEE FPSPEEDEFFECT!!!!!
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 2; //REDACTED, SEE FPSPEEDEFFECT!!!!!

		starttime = Time.time;

		flameeffect = (GameObject)Resources.Load ("flame_speed"); //REDACTED, SEE FPSPEEDEFFECT!!!!!
		flameeffect = GameObject.Instantiate (flameeffect, wiz.gameObject.transform); //REDACTED, SEE FPSPEEDEFFECT!!!!!
	}

	public override void Update() { //REDACTED, SEE FPSPEEDEFFECT!!!!!
		if (Time.time >= starttime + effectdur) {
			MonoBehaviour.Destroy (flameeffect);
			wiz.state = new NormalWizardState (wiz);
		}
		
		
	}
}