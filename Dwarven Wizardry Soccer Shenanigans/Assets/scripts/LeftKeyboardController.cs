using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKeyboardController : GameController {

	
	// Update is called once per frame
	public override void check () {
		if (Input.GetKey ("w")) { 
			up (); 
		}
		if (Input.GetKey ("s")) {
			down (); 
		}
		if (Input.GetKey ("a")) {
			left ();
		}
		if (Input.GetKey ("d")) {
			right (); 
		}
		if (Input.GetKey ("f")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("g")) {
			b2 (); 
		}
		if (Input.GetKeyDown ("v")) {
			b3 (); 
		}
		if (Input.GetKeyDown ("b")) {
			b4 (); 
		}

		
	}
}
