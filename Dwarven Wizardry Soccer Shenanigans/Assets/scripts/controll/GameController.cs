using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public Wizard controled;
	public Wizard[] controledws;




	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (controled != null) {
			controledws = new Wizard[1];
			controledws [0] = controled;

		}
		foreach (Wizard wiz in controledws) {
			wiz.controller = this;
		}
	}

	public virtual void check ()	{}

	public void up() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedup = true;
		}
	}

	public void down() {
		foreach (Wizard wiz in controledws) {
			wiz.presseddown = true;
		}
	}

	public void left() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedleft = true;
		}
	}

	public void right() {
		foreach (Wizard wiz in controledws) {
			wiz.pressedright = true;
		}
	}
	public void b1() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed1 = true;
		}
	}
	public void b2() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed2 = true;
		}
	}
	public void b3() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed3 = true;
		}
	}
	public void b4() {
		foreach (Wizard wiz in controledws) {
			wiz.pressed4 = true;
		}
	}
}
