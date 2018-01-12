using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeed : Ability {

	public FireSpeed(Wizard w) : base(w){
		cooldown = 8f;
		castduration = 0.3f;
	}

	public override void magic() {
		wiz.state = new CastIntoState (wiz, this, new FSpeedState(wiz));
	}
}
