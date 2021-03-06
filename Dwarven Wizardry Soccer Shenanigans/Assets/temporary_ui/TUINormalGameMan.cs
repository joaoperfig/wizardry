using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUINormalGameMan : MonoBehaviour {

	GameObject camera;
	CameraOrder co;
	private float start;
	public float wait = 3;
	public GameObject onegame;

	private TUIGame ongoing;

	private bool donesel = false;
	private bool waitforgame = false;

	public int totalgames=0;
	public int leftscore=0;
	public int rightscore=0;

	public GameObject leftw;
	public GameObject rightw;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		co = camera.GetComponent<CameraOrder> ();
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!donesel) {
			if (gameObject.transform.GetChild (0).gameObject.GetComponent<TUISelector> ().ready && gameObject.transform.GetChild (1).gameObject.GetComponent<TUISelector> ().ready) {
				co.GoTo (new Vector2 (0, -1.8f), 5.5f, 1);
				donesel = true;
				leftw = gameObject.transform.GetChild (0).gameObject.GetComponent<TUISelector> ().chosen;
				rightw =gameObject.transform.GetChild (1).gameObject.GetComponent<TUISelector> ().chosen;
			}
		} else {
			GameObject.Find ("NumberWindowL").GetComponent<NumberWindow> ().value = leftscore;
			GameObject.Find ("NumberWindowR").GetComponent<NumberWindow> ().value = rightscore;
			if (!waitforgame) {
				GameObject og = GameObject.Instantiate (onegame);
				ongoing = og.GetComponent<TUIGame> ();
				ongoing.leftWiz = leftw;
				ongoing.rightWiz = rightw;

				waitforgame = true;

			} else {
				if (ongoing.finished) {
					waitforgame = false;
					totalgames += 1;
					if (ongoing.winner == 1) {
						leftscore += 1;
	
					} else {
						rightscore += 1;
				
					}
					if (Mathf.Max (leftscore, rightscore) == 7) {
						Application.LoadLevel (Application.loadedLevel);
					}
					ongoing.Kill ();
				}
			}

		}
		
	}
}
