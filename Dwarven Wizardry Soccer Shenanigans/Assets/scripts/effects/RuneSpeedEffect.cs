using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSpeedEffect : WizardEffect {

	private GameObject runeeffect;
	private float effectdur = 2.5f;
	public float starttime;

	public RuneSpeedEffect(Wizard w) : base(w) {
		allowsmovement = true;

		allowsabilities = true;

		speedmodifier = 1.6f;

		starttime = Time.time;

		runeeffect = (GameObject)Resources.Load ("rune_speed");
		runeeffect = GameObject.Instantiate (runeeffect, wiz.gameObject.transform);
	}

	public override void Update() {
		if (Time.time >= starttime + effectdur) {
			MonoBehaviour.Destroy (runeeffect);
			wiz.effects.Remove (this);
			Debug.Log ("REMOVE");
		}

	}
}