﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firemancer : MonoBehaviour {


	void Start() {

		Wizard w = gameObject.GetComponent<Wizard> ();
		w.abilities = new Ability[4];
		w.abilities [0] = new BasicAbility (w);
		w.abilities [1] = new FireSpeed (w);
		w.abilities [2] = new SmallFireBall (w);
		w.abilities [3] = new BigFireBall (w);
	}
}
