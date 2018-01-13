using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direct_fireball : MonoBehaviour {

	public float initial;

	public float accel;

	public float force;

	public Vector2 direction;

	public GameObject explosion;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 delta = direction * initial*Time.deltaTime;
		initial = initial + accel * Time.deltaTime;
		gameObject.transform.position = gameObject.transform.position + new Vector3 (delta.x, delta.y, 0);	
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ball") {
			GameObject.Instantiate (explosion, this.transform.position , Quaternion.identity);
			Rigidbody2D orb = other.gameObject.GetComponent<Rigidbody2D> ();
			Vector2 diff = orb.gameObject.transform.position - gameObject.transform.position;
			orb.velocity = diff * force;
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Wall") {
			GameObject.Instantiate (explosion, this.transform.position , Quaternion.identity);
			Destroy (gameObject);
		}

	}
}
