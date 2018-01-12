using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {
	
	public Wizard wiz;
	public float cooldown;
	public float castduration;
	public Sprite logo;

	internal float last_cast = Time.time-100;

	public Ability(Wizard w){
		wiz = w;
	}
	public bool Activate() {
		if (waittime () == 0) {
			last_cast = Time.time;
			wiz.state = new CastingWizardState (wiz, this, wiz.state);
			magic ();
			return true;
		} else {
			return false;
		}
	}

	public bool canUncast() {
		float canuncast = last_cast + castduration;
		if (Time.time >= canuncast) {
			return true;
		}
		return false;
	}

	public float waittime(){
		float cancast = last_cast + cooldown;
		if (Time.time >= cancast) {
			return 0;
		}
		return cancast - Time.time;
	}

	public virtual void magic() {
	}
}
