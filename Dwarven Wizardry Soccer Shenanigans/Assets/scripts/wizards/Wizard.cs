using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

	public WizardState state;

	public Ability[] abilities;

	public GameController controller;

	public int teamtag;
	public int speedCompensation;

	public float basespeed;

	public bool pressedup = false;
	public bool presseddown = false;
	public bool pressedleft = false;
	public bool pressedright = false;
	public bool pressed1 = false;
	public bool pressed2 = false;
	public bool pressed3 = false;
	public bool pressed4 = false;

	public Vector2 lastdir;

	private Animator animator;

	public Ability ability_kick;
	public Ability ability_movement;
	public Ability ability_special_1;
	public Ability ability_special_2;

	public InputSpectator spectating;
	public bool hasspectating = false;

 
	// Use this for initialization
	void Start () {
		
		state =  new NormalWizardState (this);
		animator = gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rbd = gameObject.GetComponent<Rigidbody2D> (); 
		rbd.angularVelocity = 0;
		gameObject.transform.rotation = Quaternion.identity;
		state.Update ();
		controller.check ();
		if (state.allowsmovement) {
			Vector2 dir = new Vector2 ();
			if (pressedup)   {dir = dir + new Vector2 (0,  1);}
			if (presseddown) {dir = dir + new Vector2 (0, -1);}
			if (pressedleft) {dir = dir + new Vector2 (-1, 0);}
			if (pressedright){dir = dir + new Vector2 ( 1, 0);}

			if ((dir.x == 0) && (dir.y == 0)){
				dir = lastdir;
				stopAnimation ();
				rbd.velocity = new Vector3(0,0,0); 
			}
			else{
				dir.Normalize ();
				lastdir = dir;
				walkAnimation ();
				Vector2 delta2 = (dir * (basespeed * Time.deltaTime * state.speedmodifier));
				Vector3 delta3 = new Vector3 (delta2.x, delta2.y, 0f);
				//this.gameObject.transform.position = this.gameObject.transform.position + delta3;
				rbd.velocity = delta3 * speedCompensation;
			}
		}
		if (state.allowsabilities){
			if (pressed1) {	ability1();}
			if (pressed2) {	ability2();}
			if (pressed3) {	ability3();}
			if (pressed4) {	ability4();}
		}

		if (hasspectating) {
			spectating.watchinput (this);
		}

		pressedup = false;
		presseddown = false;
		pressedleft = false;
		pressedright = false;
		pressed1 = false;
		pressed2 = false;
		pressed3 = false;
		pressed4 = false;
	}

	public void uncastAnimation(){
		animator.SetTrigger ("uncast");
	}

	void castAnimation(){
		animator.SetTrigger ("cast");
	}
	void walkAnimation (){
		if (lastdir.x != 0) {
			if (lastdir.x > 0) {
				gameObject.transform.localScale = new Vector3 ( 1, 1, 1);
			} else {
				gameObject.transform.localScale = new Vector3 (-1, 1, 1);
			}
		}
		animator.SetTrigger ("walk");
	}
	void stopAnimation(){
		animator.SetTrigger ("stop");
	}

	void ability1(){
		if (abilities [0].Activate ()) {
			castAnimation ();	}	}
	void ability2(){
		if (abilities [1].Activate ()) {
			castAnimation ();	}	}
	void ability3(){
		if (abilities [2].Activate ()) {
			castAnimation ();	}	}
	void ability4(){
		if (abilities [3].Activate ()) {
			castAnimation ();	}	}
}
