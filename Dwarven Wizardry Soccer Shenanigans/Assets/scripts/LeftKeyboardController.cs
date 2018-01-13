using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftKeyboardController : GameController {

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
		if (Input.GetKeyDown ("f")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("g")) {
			b2 (); 
		}
		if (Input.GetKeyDown ("c")) {
			b3 (); 
		}
		if (Input.GetKeyDown ("v")) {
			b4 (); 
		}

		
	}
}
