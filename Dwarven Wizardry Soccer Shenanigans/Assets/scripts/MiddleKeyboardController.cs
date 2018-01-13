using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleKeyboardController : GameController {

	public override void check () {
		if (Input.GetKey ("6")) { 
			up (); 
		}
		if (Input.GetKey ("y")) {
			down (); 
		}
		if (Input.GetKey ("t")) {
			left ();
		}
		if (Input.GetKey ("u")) {
			right (); 
		}
		if (Input.GetKeyDown ("9")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("0")) {
			b2 (); 
		}
		if (Input.GetKeyDown ("o")) {
			b3 (); 
		}
		if (Input.GetKeyDown ("p")) {
			b4 (); 
		}


	}
}