using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUIRandWiz : MonoBehaviour {

	GameObject camera;
	CameraOrder co;
	private float start;
	public float wait = 3;
	public GameObject onegame;

	private TUIGame ongoing;

	private bool waitforgame = false;

	public int totalgames=0;
	public int leftscore=0;
	public int rightscore=0;

	public GameObject leftw;
	public GameObject rightw;

	public GameObject wiz1;
	public GameObject wiz2;
	public GameObject wiz3;
	public GameObject wiz4;
	public GameObject[] wizards;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		co = camera.GetComponent<CameraOrder> ();
		start = Time.time;
		wizards = new GameObject[4]{ wiz1, wiz2, wiz3, wiz4 };
	}

	// Update is called once per frame
	void Update () {

		GameObject.Find ("NumberWindowL").GetComponent<NumberWindow> ().value = leftscore;
		GameObject.Find ("NumberWindowR").GetComponent<NumberWindow> ().value = rightscore;
		if (!waitforgame) {
			GameObject og = GameObject.Instantiate (onegame);
			ongoing = og.GetComponent<TUIGame> ();

			leftw = wizards [Random.Range (0, wizards.Length)];
			rightw = wizards [Random.Range (0, wizards.Length)];

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
