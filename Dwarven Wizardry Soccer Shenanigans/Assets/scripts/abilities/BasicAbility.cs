using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbility : Ability {

	public float radius = 1.4f;
	public float intensity = 4;
	public float wizintensity = 8;
	public float amortice = 0.5f;
	public float distance_modifier = 1f;
	public GameObject effect;

	public BasicAbility(Wizard w) : base(w){
		cooldown = 2f;
		castduration = 0.5f;
		effect = (GameObject)Resources.Load ("firemancer_basic");
		logo = findlogo("ability_icons_1_2");
	}

	public override void magic() {
		GameObject.Instantiate (effect, wiz.transform.position + new Vector3(0f, -0.11f, 0f), Quaternion.identity);
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
		foreach (GameObject ball in balls) {
			if ((ball.transform.position - wiz.transform.position).sqrMagnitude < Mathf.Pow (radius, 2)) {
				Rigidbody2D rbd = ball.GetComponent<Rigidbody2D> ();
				Vector2 delta = ball.transform.position - wiz.transform.position;
				rbd.velocity = rbd.velocity * amortice + delta.normalized * intensity;
				rbd.velocity = rbd.velocity + delta.normalized * (radius - Mathf.Sqrt (delta.sqrMagnitude)) * distance_modifier * intensity;
			}

		}
		GameObject[] wizs = GameObject.FindGameObjectsWithTag ("Wizard");
		foreach (GameObject wi in wizs) {
			if (((wi.transform.position - wiz.transform.position).sqrMagnitude < Mathf.Pow (radius, 2)) && (wi.GetComponent<Wizard>().teamtag != wiz.GetComponent<Wizard>().teamtag)) {
				Rigidbody2D rbd = wi.GetComponent<Rigidbody2D> ();
				Vector2 delta = wi.transform.position - wiz.transform.position;
				rbd.velocity = rbd.velocity * amortice + delta.normalized * wizintensity;
				rbd.velocity = rbd.velocity + delta.normalized * (radius - Mathf.Sqrt (delta.sqrMagnitude)) * distance_modifier * wizintensity;
				wi.GetComponent<Wizard> ().effects.Add (new BasicStun (wi.GetComponent<Wizard> ()));
			}

		}
	}

}
