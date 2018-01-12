using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class implode_rune : MonoBehaviour {

	public float force;

	public float duration;
	public float destroytime;
	private float starttime;
	private bool exploded = false;

	void Start(){
		starttime = Time.time;
	}

	void Update(){
		if (Time.time > (starttime + duration)) {
			if (!(exploded)) {
				Animator anim = gameObject.GetComponent<Animator> ();
				anim.SetTrigger ("explode");
				exploded = true;
			}

		}
		if (Time.time > (starttime + duration+destroytime)) {
			Destroy (gameObject);

		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ball") {
			if (!(exploded)) {
				Animator anim = gameObject.GetComponent<Animator> ();

				anim.SetTrigger ("explode");


				Rigidbody2D orb = other.gameObject.GetComponent<Rigidbody2D> ();
				Vector2 diff = orb.gameObject.transform.position - gameObject.transform.position;
				orb.velocity = orb.velocity - diff * force;

				exploded = true;
			}

		}

	}
}
