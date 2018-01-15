using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSet : MonoBehaviour {

	public Texture2D cursor;

	// Use this for initialization
	void Start () {
		Vector3 offset = Vector3.zero;
		Cursor.SetCursor (cursor, offset, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
