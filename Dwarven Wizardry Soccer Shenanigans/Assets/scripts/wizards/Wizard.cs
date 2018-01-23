using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

	public WizardState state;
	public List<WizardEffect> effects;

	public Ability[] abilities;

	public GameController controller;

	public int teamtag;
	public int speedCompensation;

	public float basespeed;
	public float brakes;

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
		effects = new List<WizardEffect> ();
		state =  new NormalWizardState (this);
		animator = gameObject.GetComponent<Animator> ();

	}

	public bool effectsallowmovement(){
		foreach (WizardEffect ef in effects) {
			if (!ef.allowsmovement) {
				return false;
			}
		}
		return true;
	}

	public bool effectsallowabilities(){
		foreach (WizardEffect ef in effects) {
			if (!ef.allowsabilities) {
				return false;
			}
		}
		return true;
	}

	public float effectspeedmodifiers(){
		float res = 1;
		foreach (WizardEffect ef in effects) {
			res = res * ef.speedmodifier;
		}
		return res;
	}

	public void UpdateEffects(){
		foreach (WizardEffect ef in effects) {
			ef.Update ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D rbd = gameObject.GetComponent<Rigidbody2D> (); 
		rbd.angularVelocity = 0;
		gameObject.transform.rotation = Quaternion.identity;
		state.Update ();
		UpdateEffects ();
		controller.check ();

		bool zerodir = false;
		Vector2 dir = new Vector2 ();                       //calculates this so that arrow works despite not being allowed to move
		if (pressedup)   {dir = dir + new Vector2 (0,  1);}
		if (presseddown) {dir = dir + new Vector2 (0, -1);}
		if (pressedleft) {dir = dir + new Vector2 (-1, 0);}
		if (pressedright){dir = dir + new Vector2 ( 1, 0);}

		if ((dir.x == 0) && (dir.y == 0)){
			dir = lastdir;
			rbd.velocity = rbd.velocity * Mathf.Pow (brakes, Time.deltaTime);
			stopAnimation ();
			zerodir = true;
		}

		if (state.allowsmovement && effectsallowmovement()) {

			if (zerodir){
				//was moved to out of allowsmovement verification;
			}
			else{
				dir.Normalize ();
				walkAnimation ();
				Vector2 delta2 = (dir * (basespeed * Time.deltaTime * state.speedmodifier * effectspeedmodifiers()));
				Vector3 delta3 = new Vector3 (delta2.x, delta2.y, 0f);
				//this.gameObject.transform.position = this.gameObject.transform.position + delta3;

				delta3 = delta3 * speedCompensation;

				//ensures that if the player is going fast forward, he doesnt instantly slow down for keeping on walking
				if (rbd.velocity.x * delta3.x > 0) {     // if velocity points in the same direction as walking
					float maybex = Mathf.Max (rbd.velocity.x, -rbd.velocity.x, delta3.x, -delta3.x); // new velocity.x will be max(oldvelocity.x, walking.x)
					if (delta3.x < 0) {
						maybex = -maybex;
					}
					delta3.x = maybex;
				}
				//ensures that if the player is going fast forward, he doesnt instantly slow down for keeping on walking
				if (rbd.velocity.y * delta3.y > 0) {        
					float maybey = Mathf.Max (rbd.velocity.y, -rbd.velocity.y, delta3.y, -delta3.y);
					if (delta3.y < 0) {
						maybey = -maybey;
					}
					delta3.y = maybey;
				}

				rbd.velocity = delta3;

				lastdir = dir;
			}
		}
		if (state.allowsabilities &&  effectsallowabilities()){
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
