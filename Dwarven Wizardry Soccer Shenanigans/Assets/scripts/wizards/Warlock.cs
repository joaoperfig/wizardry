using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warlock : MonoBehaviour {

	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new TentacleBasic (w);
		w.abilities [1] = new TentacleTrail (w);
		w.abilities [2] = new Tentacle (w);
		w.abilities [3] = new TentacleGhost (w);
	}
}
