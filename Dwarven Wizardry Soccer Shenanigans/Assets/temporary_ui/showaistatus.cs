using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showaistatus : MonoBehaviour {

	public Sprite has;
	public Sprite nohas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.parent.gameObject.GetComponent<TempUI> ().ai) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = has;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = nohas;
		}
	}
}
