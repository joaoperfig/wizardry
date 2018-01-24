using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private Wizard wiz;

	public float distance;

	// Use this for initialization
	void Start () {
		wiz = gameObject.transform.parent.gameObject.GetComponent<Wizard> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 dir = wiz.lastdir;
		float rotat = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
		Vector2 pos = dir * distance;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );
		gameObject.transform.localPosition = new Vector3 (Mathf.Abs(pos.x), pos.y, 0);
	}
}
