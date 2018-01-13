using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightKeyboardController : GameController {

	public override void check () {
		if (Input.GetKey ("up")) { 
			up (); 
		}
		if (Input.GetKey ("down")) {
			down (); 
		}
		if (Input.GetKey ("left")) {
			left ();
		}
		if (Input.GetKey ("right")) {
			right (); 
		}
		if (Input.GetKeyDown ("h")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("j")) {
			b2 (); 
		}
		if (Input.GetKeyDown ("n")) {
			b3 (); 
		}
		if (Input.GetKeyDown ("m")) {
			b4 (); 
		}


	}
}