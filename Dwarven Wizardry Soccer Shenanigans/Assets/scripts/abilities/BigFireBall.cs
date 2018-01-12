using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFireBall : Ability {

	public GameObject fireball;

	public BigFireBall(Wizard w) : base(w){
		cooldown = 4f;
		castduration = 0.5f;
		fireball = (GameObject)Resources.Load ("fireball_big");
	}

	public override void magic() {
		GameObject f = GameObject.Instantiate (fireball, wiz.transform.position + new Vector3(0f, -0.11f, 0f), Quaternion.identity);
		direct_fireball df = f.GetComponent<direct_fireball> ();
		df.direction = wiz.lastdir.normalized;
		float rotat = Mathf.Atan2 (df.direction.x, df.direction.y) * Mathf.Rad2Deg;
		f.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );
	}
}

