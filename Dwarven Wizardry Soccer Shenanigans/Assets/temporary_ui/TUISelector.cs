﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUISelector : MonoBehaviour {

	public string left;
	public string right;
	public string enter1;
	public string enter2;
	public string enter3;
	public string enter4;
	public string enter5;

	public bool ready = false;

	public Sprite sw1;
	public GameObject wz1;

	public Sprite sw2;
	public GameObject wz2;

	public Sprite sw3;
	public GameObject wz3;

	public Sprite sw4;
	public GameObject wz4;

	public Sprite sw5;
	public GameObject wz5;

	public Sprite sw6;
	public GameObject wz6;

	private int index = 0;

	private Sprite[] images;
	private GameObject[] wizards;

	public GameObject chosen;

	// Use this for initialization
	void Start () {
		images = new Sprite[6] {sw1, sw2, sw3, sw4, sw5, sw6};
		wizards = new GameObject[6] {wz1, wz2, wz3, wz4, wz5, wz6};

		
	}

	// Update is called once per frame
	void Update () {
		if (!ready) {
			if (Input.GetKeyDown (left)) {
				index = index + 1;
			}
			if (Input.GetKeyDown (right)) {
				index = index - 1;
			}
			if (index == -1)
				index = 5;
			if (index == 6)
				index = 0;

			gameObject.GetComponent<SpriteRenderer> ().sprite = images [index];
			chosen = wizards[index];
		}

		if (Input.GetKeyDown (enter1) || Input.GetKeyDown (enter2) || Input.GetKeyDown (enter3) || Input.GetKeyDown (enter4) || Input.GetKeyDown (enter5)) {
			ready = !ready;
			if (ready) {
				transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			} else {
				transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
			}
		}
	}
}
