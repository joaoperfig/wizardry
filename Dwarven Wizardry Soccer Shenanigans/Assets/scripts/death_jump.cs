using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_jump : MonoBehaviour {

	public Wizard died;
	public float duration;

	private GameObject returncourier;
	private GameObject smoke;
	private float starttime;

	private bool activated = false;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
		returncourier = (GameObject)Resources.Load ("death_return");
		smoke = (GameObject)Resources.Load ("death_explosion");
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.rotation = Quaternion.identity;
		if (!activated && (Time.time > starttime + duration)) {
			activated = true;
			GameObject.Instantiate (smoke, died.transform.position, Quaternion.identity);
			GameObject cou = GameObject.Instantiate (returncourier, died.transform.position, Quaternion.identity);
			death_return dr = cou.GetComponent<death_return> ();
			dr.carrying = died;
			dr.skeleton = this;
			died.state = new CourriedWizardState (died);

			gameObject.GetComponent<Animator> ().SetTrigger ("return");
		}
	}

	public void arrived(){
		Destroy (gameObject);
	}
}
