using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireBall : Ability {

	public GameObject fireball;

	public BigFireBall(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 0.5f;
		fireball = (GameObject)Resources.Load ("fireball_big");
		logo = findlogo("ability_icons_1_5");
	}

	public override void magic() {
		//code that moves the fireball towards the middle of the field to avoid it olliding with walls on spawn
		Vector3 gpos1 = GameObject.Find ("LeftGoal").transform.position;
		Vector3 gpos2 = GameObject.Find ("RightGoal").transform.position;
		Vector3 mid = (gpos1 + gpos2) * 0.5f;
		Vector3 delta = mid - wiz.transform.position;
		delta = delta * 0.025f;
		// detla pushes the ball to the middle

		GameObject f = GameObject.Instantiate (fireball, wiz.transform.position + delta, Quaternion.identity);
		direct_fireball df = f.GetComponent<direct_fireball> ();
		df.direction = wiz.lastdir.normalized;
		float rotat = Mathf.Atan2 (df.direction.x, df.direction.y) * Mathf.Rad2Deg;
		f.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );
	}
}

