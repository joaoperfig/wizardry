using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireBall : Ability {

	public GameObject fireball;

	public SmallFireBall(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 0.5f;
		fireball = (GameObject)Resources.Load ("small_fireball");
	}

	public override void magic() {
		GameObject.Instantiate (fireball, wiz.transform.position + new Vector3(0f, -0.11f, 0f), Quaternion.identity);
	}
}
