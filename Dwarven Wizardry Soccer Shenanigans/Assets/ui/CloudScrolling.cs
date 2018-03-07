using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScrolling : MonoBehaviour {

	private Vector3 initpos;

	public float vel;

	// Use this for initialization
	void Start () {
		initpos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newpos = gameObject.transform.position;
		newpos = newpos + new Vector3 (vel * Time.deltaTime, 0, 0);
		gameObject.transform.position = newpos;
		if (gameObject.transform.GetChild (0).position.x > initpos.x) {
			gameObject.transform.position = initpos;
		}
	}
}
