using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possession_entity : MonoBehaviour {

	public float distance;

	private float angle = 0;

	public float speed;

	public float force;

	public GameObject ball;

	public Wizard carried;

	private InputSpectator input;

	private GameObject smoke;

	// Use this for initialization
	void Start () {
		input = gameObject.GetComponent<InputSpectator> ();	
		smoke = (GameObject)Resources.Load ("smoke_explosion");
	}
	
	// Update is called once per frame
	void Update () {
		carried.spectating = input;
		carried.hasspectating = true;

		gameObject.transform.parent.position = ball.transform.position;

		angle = angle - speed * Time.deltaTime;
		while (angle < 0) {
			angle = angle + 360;
		}
		Vector2 delta = new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad));
		delta = delta.normalized * distance;
		gameObject.transform.localPosition = new Vector3 (delta.x, delta.y, 0);

		if (ball.GetComponent<Ball> ().state.canreach) {
			if (((input.pressed1) || (input.pressed2)) || ((input.pressed3) || (input.pressed4))) {
				delta = new Vector2 (Mathf.Cos (angle * Mathf.Deg2Rad), Mathf.Sin (angle * Mathf.Deg2Rad));
				Rigidbody2D rbd = ball.gameObject.GetComponent<Rigidbody2D> ();
				rbd.AddForce (-delta * force);
				GameObject.Instantiate (smoke, this.transform.position, Quaternion.identity);
				carried.hasspectating = false;
				carried.state = new NormalWizardState (carried);
				carried.gameObject.transform.position = gameObject.transform.position;
				Destroy (transform.parent.gameObject);
				Destroy (gameObject);
			}
		}
		
	}
}
