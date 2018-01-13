using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSpectator : MonoBehaviour {

	public bool pressedup = false;
	public bool presseddown = false;
	public bool pressedleft = false;
	public bool pressedright = false;
	public bool pressed1 = false;
	public bool pressed2 = false;
	public bool pressed3 = false;
	public bool pressed4 = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void watchinput(Wizard w){
		pressedup = w.pressedup;
		presseddown = w.presseddown;
		pressedleft = w.pressedleft;
		pressedright = w.pressedright;
		pressed1 = w.pressed1;
		pressed2 = w.pressed2;
		pressed3 = w.pressed3;
		pressed4 = w.pressed4;
	}
}
