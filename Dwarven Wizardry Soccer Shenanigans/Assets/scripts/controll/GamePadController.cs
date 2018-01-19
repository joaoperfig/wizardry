using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class GamePadController : GameController {

	private GamePad.Index ind;

	public int indx;

	public override void check () {
		switch (indx) {
		case 1:
			ind = GamePad.Index.One;
			break;
		case 2:
			ind = GamePad.Index.Two;
			break;
		case 3:
			ind = GamePad.Index.Three;
			break;
		case 4:
			ind = GamePad.Index.Four;
			break;
		default:
			ind = GamePad.Index.Any;
			break;
		}

		Vector2 dir = GamePad.GetAxis (GamePad.Axis.Dpad, ind) + GamePad.GetAxis (GamePad.Axis.LeftStick, ind) + GamePad.GetAxis (GamePad.Axis.RightStick, ind);
		if (dir.y > 0) { 
			up (); 
		}
		if (dir.y<0) {
			down (); 
		}
		if (dir.x<0) {
			left ();
		}
		if (dir.x >0) {
			right (); 
		}
		if (GamePad.GetButtonDown (GamePad.Button.A, ind)) {
			b1 (); 
		}
		if (GamePad.GetButtonDown (GamePad.Button.Y, ind)) {
			b2 (); 
		}
		if (GamePad.GetButtonDown (GamePad.Button.B, ind)) {
			b3 (); 
		}
		if (GamePad.GetButtonDown (GamePad.Button.X, ind)) {
			b4 (); 
		}


	}
}