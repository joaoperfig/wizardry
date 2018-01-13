using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occultist : MonoBehaviour {


	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new ShadowBasic (w);
		w.abilities [1] = new ShadowJump (w);
		w.abilities [2] = new ShadowSwap (w);
		w.abilities [3] = new ShadowPossession (w);
	}
}
