using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fdash_effect : MonoBehaviour {

	public Vector2 direction;
	public GameObject follow;
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

		Vector2 pos =  new Vector2(follow.transform.position.x, follow.transform.position.y) + direction.normalized * distance;
		gameObject.transform.position = new Vector3 (pos.x, pos.y, 0);

		float rotat = Mathf.Atan2 (direction.normalized.x, direction.normalized.y) * Mathf.Rad2Deg;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, 180-rotat );
	}
}
