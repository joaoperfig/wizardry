using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAExit : ButtonAction {

	public override void action(){
		Debug.Log ("exiting");
		Application.Quit ();
		Debug.Log ("in editor");
	}
}
