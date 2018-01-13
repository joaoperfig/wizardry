using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke_courier : MonoBehaviour {

	public Vector2 direction;

	public Wizard carrying;

	public float speed;

	public float maxdistance;

	private Vector3 start;

	private GameObject smoke;

	// Use this for initialization
	void Start () {
		start = gameObject.transform.position;
		smoke = (GameObject)Resources.Load ("smoke_explosion");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 delta = direction.normalized * speed * Time.deltaTime;
		gameObject.transform.position = gameObject.transform.position + new Vector3 (delta.x, delta.y, 0);

		if ((gameObject.transform.position - start).magnitude > maxdistance) {
			Drop ();
		}
	}

	void Drop() {
		carrying.state = new NormalWizardState (carrying);
		carrying.gameObject.transform.position = gameObject.transform.position;
		GameObject.Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Wall") {
			GameObject.Instantiate (smoke, this.transform.position , Quaternion.identity);
			Drop ();
		}

	}
}
