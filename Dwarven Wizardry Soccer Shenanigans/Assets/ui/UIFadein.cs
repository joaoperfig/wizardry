using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadein : MonoBehaviour {

	private Image img;
	private float starttime;

	// Use this for initialization
	void Start () {
		img = gameObject.GetComponent<Image> ();
		starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float a = (Time.time - starttime) / 1; // duration of fade
		if (a < 1) 
			img.color = new Color (1f, 1f, 1f, a);
		else
			img.color = Color.white;
	}
}
