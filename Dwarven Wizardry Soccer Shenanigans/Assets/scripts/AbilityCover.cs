using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCover : MonoBehaviour {

	public float percentage;

	public Sprite s0;
	public Sprite s1;
	public Sprite s2;
	public Sprite s3;
	public Sprite s4;
	public Sprite s5;
	public Sprite s6;
	public Sprite s7;
	public Sprite s8;
	public Sprite s9;
	public Sprite s10;
	public Sprite s11;
	public Sprite s12;

	private Sprite[] list;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		list = new Sprite[13];
		list [0] = s0;
		list [1] = s1;
		list [2] = s2;
		list [3] = s3;
		list [4] = s4;
		list [5] = s5;
		list [6] = s6;
		list [7] = s7;
		list [8] = s8;
		list [9] = s9;
		list [10] = s10;
		list [11] = s11;
		list [12] = s12;
	}
	
	// Update is called once per frame
	void Update () {
		Sprite chosen;
		if (percentage <= 0) {
			chosen = list [12];
		} else if (percentage >= 100) {
			chosen = list [0];
		} else {
			chosen = list [11-(int)(12 * percentage / 100)];
		}
		sr.sprite = chosen;
	}
}
