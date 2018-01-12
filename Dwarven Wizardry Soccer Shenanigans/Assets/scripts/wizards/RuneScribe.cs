using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneScribe : MonoBehaviour {

	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new RuneBasic (w);
		w.abilities [1] = new RuneTeleport (w);
		w.abilities [2] = new RuneExplode (w);
		w.abilities [3] = new RuneImplode (w);
	}
}
