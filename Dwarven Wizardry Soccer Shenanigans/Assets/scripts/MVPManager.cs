using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVPManager : MonoBehaviour {

	private float start;

	public GameObject selector;
	public GameObject randw;
	public GameObject randa;

	public GameObject leftc;
	public GameObject rightc;

	public bool ai = false;

	GameObject camera;
	CameraOrder co;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		co = camera.GetComponent<CameraOrder> ();
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void ToSelect(){
		co.GoTo (new Vector2 (16f, 3.25f), 3.5f, 2);
		GameObject.Instantiate (selector);
	}

	public void ToRandomW(){
		co.GoTo (new Vector2 (0, -1.8f), 5.5f, 1);
		GameObject.Instantiate (randw);
	}

	public void ToAllRandom(){
		co.GoTo (new Vector2 (0, -1.8f), 5.5f, 1);
		GameObject.Instantiate (randa);
	}
}
