using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeed : Ability {

	public FireSpeed(Wizard w) : base(w){
		cooldown = 8f;
		castduration = 0.3f;
		logo = findlogo("ability_icons_1_3");
	}

	public override void magic() {
		wiz.state = new CastIntoEffect (wiz, this, new FPSpeedEffect (wiz), wiz.state);
	}
}
