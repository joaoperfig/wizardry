using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public Wizard controled;
	public Wizard[] controledws;




	// Use this for initialization
	void Start () {
		if (controled != null) {
			controledws = new Wizard[1];
			controledws [0] = controled;
		} 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void check ()	{}

	internal void up() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedup = true;
		}
	}

	internal void down() {
		foreach (Wizard wiz in controledws) {
			wiz.presseddown = true;
		}
	}

	internal void left() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedleft = true;
		}
	}

	internal void right() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedright = true;
		}
	}
	internal void b1() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed1 = true;
		}
	}
	internal void b2() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed2 = true;
		}
	}
	internal void b3() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed3 = true;
		}
	}
	internal void b4() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed4 = true;
		}
	}
}
