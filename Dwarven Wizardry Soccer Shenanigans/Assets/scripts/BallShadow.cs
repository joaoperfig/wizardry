using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShadow : MonoBehaviour {

	public GameObject ball;

	public float distance;

	public float speeddistance;

	public float max;

	private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {
		rbd = ball.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 delta = new Vector3 (0, Mathf.Max (-(distance + speeddistance * rbd.velocity.magnitude), -max), 0);
		gameObject.transform.position = ball.transform.position + delta;
	}
}
