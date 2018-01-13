using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpull_effect : MonoBehaviour {

	public GameObject follow;
	public GameObject pointto;
	public float duration;
	public float distance;

	private float start;
	// Use this for initialization
	void Start () {
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > start + duration) {
			Destroy (gameObject);
		}

		Vector2 delta = pointto.transform.position - follow.transform.position;

		Vector2 pos =  new Vector2(follow.transform.position.x, follow.transform.position.y) + delta.normalized * distance;
		gameObject.transform.position = new Vector3 (pos.x, pos.y, 0);

		float rotat = Mathf.Atan2 (delta.normalized.x, delta.normalized.y) * Mathf.Rad2Deg;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, -rotat );
	}
}
