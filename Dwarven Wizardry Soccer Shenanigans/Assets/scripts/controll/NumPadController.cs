using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPadController : GameController {

	public override void check () {
		if (Input.GetKey (KeyCode.Keypad8)) { 
			up (); 
		}
		if (Input.GetKey (KeyCode.Keypad5)) {
			down (); 
		}
		if (Input.GetKey (KeyCode.Keypad4)) {
			left ();
		}
		if (Input.GetKey (KeyCode.Keypad6)) {
			right (); 
		}
		if (Input.GetKeyDown (KeyCode.Keypad1)) {
			b1 (); 
		}
		if (Input.GetKeyDown (KeyCode.Keypad2)) {
			b2 (); 
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)) {
			b3 (); 
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter)) {
			b4 (); 
		}


	}
}