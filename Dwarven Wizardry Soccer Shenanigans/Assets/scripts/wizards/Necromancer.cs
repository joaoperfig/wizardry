using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour {

	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new DeathBasic (w);
		w.abilities [1] = new DeathJump (w);
		w.abilities [2] = new DeathZombie (w);
		w.abilities [3] = new DeathSkeleton (w);
	}
}
