using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWindow : MonoBehaviour {

	public Wizard wiz;

	private SpriteRenderer ab1;
	private SpriteRenderer ab2;
	private SpriteRenderer ab3;
	private SpriteRenderer ab4;

	private AbilityCover ac1;
	private AbilityCover ac2;
	private AbilityCover ac3;
	private AbilityCover ac4;

	// Use this for initialization
	void Start () {
		ab1 = gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ();
		ab2 = gameObject.transform.GetChild (1).gameObject.GetComponent<SpriteRenderer> ();
		ab3 = gameObject.transform.GetChild (2).gameObject.GetComponent<SpriteRenderer> ();
		ab4 = gameObject.transform.GetChild (3).gameObject.GetComponent<SpriteRenderer> ();

		ac1 = gameObject.transform.GetChild (4).gameObject.GetComponent<AbilityCover> ();
		ac2 = gameObject.transform.GetChild (5).gameObject.GetComponent<AbilityCover> ();
		ac3 = gameObject.transform.GetChild (6).gameObject.GetComponent<AbilityCover> ();
		ac4 = gameObject.transform.GetChild (7).gameObject.GetComponent<AbilityCover> ();
	}
	
	// Update is called once per frame
	void Update () {
		ab1.sprite = wiz.abilities [0].logo;
		ab2.sprite = wiz.abilities [1].logo;
		ab3.sprite = wiz.abilities [2].logo;
		ab4.sprite = wiz.abilities [3].logo;

		float percentage;
		Ability curr;

		curr = wiz.abilities [0];
		percentage = 100 * curr.waittime() / curr.cooldown;
		ac1.percentage = percentage;
		if (percentage == 0) {
			ab1.color = new Color (1,1,1);
		} else {
			ab1.color = new Color (0.5f, 0.5f, 0.5f);
		}

		curr = wiz.abilities [1];
		percentage = 100 * curr.waittime() / curr.cooldown;
		ac2.percentage = percentage;
		if (percentage == 0) {
			ab2.color = new Color (1,1,1);
		} else {
			ab2.color = new Color (0.5f, 0.5f, 0.5f);
		}

		curr = wiz.abilities [2];
		percentage = 100 * curr.waittime() / curr.cooldown;
		ac3.percentage = percentage;
		if (percentage == 0) {
			ab3.color = new Color (1,1,1);
		} else {
			ab3.color = new Color (0.5f, 0.5f, 0.5f);
		}

		curr = wiz.abilities [3];
		percentage = 100 * curr.waittime() / curr.cooldown;
		ac4.percentage = percentage;
		if (percentage == 0) {
			ab4.color = new Color (1,1,1);
		} else {
			ab4.color = new Color (0.5f, 0.5f, 0.5f);
		}
	
	}
}
