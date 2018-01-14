using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUI : MonoBehaviour {

	private int selected = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("down") || Input.GetKeyDown ("s")) {
			selected = selected + 1;
		}
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("w")) {
			selected = selected - 1;
		}
		if (selected == -1)
			selected = 2;
		if (selected == 3)
			selected = 0;

		transform.GetChild (3).position = transform.GetChild (selected).position;

		if (Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space)) {
			GameObject man = GameObject.Find ("Manager");
			MVPManager mvp = man.GetComponent<MVPManager> ();
			if (selected == 0) {
				mvp.ToSelect ();
			}
			else if (selected == 1) {
				mvp.ToRandomW ();
			} else {
				mvp.ToAllRandom ();
			}
			Destroy (this);
		}
	}
}
