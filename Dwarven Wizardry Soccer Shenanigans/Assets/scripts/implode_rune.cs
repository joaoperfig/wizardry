using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class implode_rune : MonoBehaviour {

	public float force;
	public int friendlyteam;

	public float duration;
	public float destroytime;
	private float starttime;
	private bool exploded = false;


	void Start(){
		starttime = Time.time;
	}

	void Update(){
		if (Time.time > (starttime + duration)) {
			if (!(exploded)) {
				Animator anim = gameObject.GetComponent<Animator> ();
				anim.SetTrigger ("explode");
				exploded = true;
			}

		}
		if (Time.time > (starttime + duration+destroytime)) {
			Destroy (gameObject);

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Wizard") {
			if (!(exploded)) {
				Wizard collided = other.GetComponent<Wizard> ();
				if (collided.teamtag == friendlyteam) {
					bool found = false;
					foreach (WizardEffect ef in collided.effects) {
						if (ef is RuneSpeedEffect) {
							((RuneSpeedEffect)ef).starttime = Time.time;
							found = true;
						}

					}
					if (!found) {
						collided.effects.Add (new RuneSpeedEffect (collided));
					}


				} else {
					
					Animator anim = gameObject.GetComponent<Animator> ();
					anim.SetTrigger ("explode");


					collided.effects.Add (new RuneStunEffect (collided));

					exploded = true;
				}
			}

		}

	}
}
