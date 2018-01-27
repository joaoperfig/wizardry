using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dark_trail : MonoBehaviour {
	
	public int friendlyteam;

	public float duration;

	private float starttime;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > starttime + duration) {
			gameObject.GetComponent<Animator> ().SetTrigger ("end");
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Wizard") {
			if (other.gameObject.GetComponent<Wizard> ().teamtag != friendlyteam) {
				Wizard collided = other.GetComponent<Wizard> ();
				bool found = false;
				foreach (WizardEffect ef in collided.effects) {
					if (ef is TrailSlowEffect) {
						((TrailSlowEffect)ef).starttime = Time.time;
						found = true;
					}

				}
				if (!found) {
					collided.effects.Add (new TrailSlowEffect (collided));
				}
			}
		}

	}
}