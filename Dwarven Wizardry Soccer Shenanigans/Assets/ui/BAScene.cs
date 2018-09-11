using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BAScene : ButtonAction {

	public string scenename;

	// Use this for initialization
	void Start () {
	}

	public override void action(){
		Debug.Log ("Opening scene");
		SceneManager.LoadScene (scenename);
	}
		
}
