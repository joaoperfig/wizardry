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
		if (Input.GetKeyDown ("n")) {
			b1 (); 
		}
		if (Input.GetKeyDown ("m")) {
			b2 (); 
		}
		if (Input.GetKeyDown (KeyCode.Comma)) {
			b3 (); 
		}
		if (Input.GetKeyDown (".")) {
			b4 (); 
		}


	}
}