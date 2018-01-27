using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
	public float rotSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), rotSpeed * Time.deltaTime);
	}
}
