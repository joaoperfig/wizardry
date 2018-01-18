using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrder : MonoBehaviour {

	private float duration;
	private Vector3 destination;
	private Vector3 increment;
	private float timefromlast;
	private bool ismoving=false;

	private Camera cam;
	private float destisize;
	private float sizeinc;

	// Use this for initialization
	void Start () {
		cam = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ismoving) {
			if (Time.time >= timefromlast + duration) {
				gameObject.transform.position = destination;
				cam.orthographicSize = destisize;
				ismoving = false;
			} else {
				gameObject.transform.position = gameObject.transform.position + increment * Time.deltaTime;
				cam.orthographicSize = cam.orthographicSize + sizeinc*Time.deltaTime;
			}
		}
		
	}

	public void GoTo(Vector2 pos, float size, float time){
		ismoving = true;
		timefromlast = Time.time;
		duration = time;
		destisize = size;
		destination = new Vector3 (pos.x, pos.y, -10);
		Vector3 delta = destination - gameObject.transform.position;
		increment = delta / time;
		sizeinc = (size-cam.orthographicSize)  / time;
	}
}
