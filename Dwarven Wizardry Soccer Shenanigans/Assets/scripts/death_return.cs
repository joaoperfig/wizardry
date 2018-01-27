using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_return : MonoBehaviour {
	
	public Wizard carrying;

	public float speed;

	public float dropdistance;

	public death_jump skeleton;

	private GameObject smoke;


	// Use this for initialization
	void Start () {
		smoke = (GameObject)Resources.Load ("death_explosion");
	}

	// Update is called once per frame
	void Update () {
		Vector2 delta = (skeleton.gameObject.transform.position - gameObject.transform.position).normalized * speed * Time.deltaTime;
		gameObject.transform.position = gameObject.transform.position + new Vector3 (delta.x, delta.y, 0);

		if ((skeleton.gameObject.transform.position - gameObject.transform.position).magnitude < dropdistance) {
			Drop ();
		}


		float rotat = Mathf.Atan2 (delta.normalized.x, delta.normalized.y) * Mathf.Rad2Deg;
		gameObject.transform.rotation = Quaternion.Euler (0f, 0f, 90-rotat );
	}

	void Drop() {
		carrying.state = new NormalWizardState (carrying);
		carrying.gameObject.GetComponent<Animator> ().SetTrigger ("uncast"); //prevents dude getting stuck on cast animation if he was casting when ge got carried back
		carrying.gameObject.transform.position = skeleton.gameObject.transform.position;
		skeleton.arrived ();
		GameObject.Instantiate (smoke, skeleton.gameObject.transform.position , Quaternion.identity);
		Destroy (gameObject);
	}
		
}