using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BACourtain : ButtonAction {

	public Courtain court;
	private float duration;
	public string scenename;

	// Use this for initialization
	void Start () {
		duration = court.duration;
	}
	
	public override void action(){
		gameObject.transform.parent.gameObject.GetComponent<MenuPanel> ().active = false; //Turn menu off
		court.Go ();
		StartCoroutine (openScene ());
	}

	IEnumerator openScene(){
		yield return new WaitForSeconds (duration);
		Debug.Log ("New Scene Loading");
		SceneManager.LoadScene (scenename);
	}
}
