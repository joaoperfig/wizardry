using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_rune : MonoBehaviour {

	private float timer;
	private float todie = 2;
	private bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered) {
			if (Time.time > todie + timer) {
				Destroy (gameObject);
			}
		}
	}

	public void activate(){
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.SetTrigger ("activate");
		triggered = true;
		timer = Time.time;
	}
}
