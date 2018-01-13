using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float animspeedscalar;

	private Animator anim;
	private Rigidbody2D rbd;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Goal") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		rbd = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("speed", animspeedscalar*Mathf.Sqrt (rbd.velocity.sqrMagnitude));
	}
}
