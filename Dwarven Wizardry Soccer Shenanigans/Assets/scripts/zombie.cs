using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour {

	public float friendlyteam;
	public float speed;
	public float duration;

	private float starttime;
	// Use this for initialization
	void Start () {
		starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.GetComponent<Rigidbody2D> ().angularVelocity = 0;
		gameObject.transform.rotation = Quaternion.identity;

		if (Time.time > starttime + duration)gameObject.GetComponent<Animator> ().SetTrigger ("die");
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("dead")) return;
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("destroyed")) Destroy(gameObject);
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("start")) return;

		GameObject otherw = null; // Wizard to follow
		GameObject[] wizs = GameObject.FindGameObjectsWithTag ("Wizard");
		bool selected = false;
		foreach (GameObject ow in wizs) {
			Wizard wscript = ow.GetComponent<Wizard> ();
			if (wscript.teamtag != friendlyteam) {
				if (selected) {
					if ((gameObject.transform.position - ow.transform.position).sqrMagnitude <= (gameObject.transform.position - otherw.transform.position).sqrMagnitude) {
						otherw = ow;
					}
				} else {
					otherw = ow;
					selected = true;
				}
			}
		}

		Vector3 delta3 = (otherw.transform.position - gameObject.transform.position).normalized;
		Vector2 delta2 = new Vector2 (delta3.x, delta3.y).normalized;
		gameObject.GetComponent<Rigidbody2D> ().velocity = delta2 * speed;
	}
}
