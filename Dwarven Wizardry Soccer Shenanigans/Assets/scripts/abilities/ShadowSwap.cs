using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSwap : Ability {

	public GameObject smoke;

	private GameObject otherw;

	public ShadowSwap(Wizard w) : base(w){
		cooldown = 8f;
		castduration = 0.5f;
		smoke = (GameObject)Resources.Load ("smoke_explosion");
		logo = findlogo("abilty_icons_shadow_4");
	}

	public override void magic() {
		otherw = null;
		GameObject[] wizs = GameObject.FindGameObjectsWithTag ("Wizard");
		bool selected = false;
		foreach (GameObject ow in wizs) {
			Wizard wscript = ow.GetComponent<Wizard> ();
			if (wscript.teamtag != wiz.teamtag) {
				if (selected) {
					if ((wiz.transform.position - ow.transform.position).sqrMagnitude <= (wiz.transform.position - otherw.transform.position).sqrMagnitude) {
						if (wscript.state.allowswap) {
							otherw = ow;
						} else {
							Debug.Log ("a swap was not allowed");
						}
					}
				} else {
					if (wscript.state.allowswap) {
						otherw = ow;
						selected = true;
					} else {
						Debug.Log ("a swap was not allowed");
					}
				}
			}
		}

		if (otherw == null) {
			GameObject.Instantiate (smoke, wiz.transform.position, Quaternion.identity);
			return;
		}

		GameObject.Instantiate (smoke, wiz.transform.position, Quaternion.identity);

		GameObject.Instantiate (smoke, otherw.transform.position, Quaternion.identity);

		Vector3 carry = wiz.gameObject.transform.position;
		wiz.gameObject.transform.position = otherw.gameObject.transform.position;
		otherw.gameObject.transform.position = carry;

	}
}

