using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleKeyboardController : GameController {

	public override void check () {
		if (Input.GetKey ("y")) { 
			up (); 
		}
		if (Input.GetKey ("h")) {
			down (); 
		}
		if (Input.GetKey ("g")) {
			left ();
		}
		if (Input.GetKey ("j")) {
			right (); 
		}
		if (Input.GetKeyDown ("7")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("8")) {
			b2 (); 
		}
		if (Input.GetKeyDown ("9")) {
			b3 (); 
		}
		if (Input.GetKeyDown ("0")) {
			b4 (); 
		}


	}
}