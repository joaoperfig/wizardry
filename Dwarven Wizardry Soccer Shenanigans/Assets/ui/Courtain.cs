using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courtain : MonoBehaviour {

	public float verticaldist;
	public float duration;
	private Vector3 startpos;
	private float starttime;
	private bool going = false;
	private Vector3 endpos;

	// Use this for initialization
	void Start () {
		startpos = gameObject.transform.localPosition;	
		endpos = startpos + new Vector3 (0, verticaldist, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (going) {
			float prog = (Time.time - starttime) / (duration);
			gameObject.transform.localPosition = Vector3.Lerp (startpos, endpos, prog);
			if (prog >= 1) {
				gameObject.transform.localPosition = endpos;
				going = false;
			}
		}
	}

	public void Go(){
		starttime = Time.time;
		going = true;
	}
}
