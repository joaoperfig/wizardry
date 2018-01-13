using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thaumaturge : MonoBehaviour {

	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new ForceBasic (w);
		w.abilities [1] = new ForceDash (w);
		w.abilities [2] = new ForcePull (w);
		w.abilities [3] = new ForceBall (w);
	}
}