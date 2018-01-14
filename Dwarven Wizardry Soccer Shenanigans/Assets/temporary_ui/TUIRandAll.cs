using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUIRandAll : MonoBehaviour {


	GameObject camera;
	CameraOrder co;
	private float start;
	public float wait = 3;
	public GameObject onegame;

	private TUIGame ongoing;

	public bool waitforgame = false;

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

		GameObject.Find ("NumberWindowL").GetComponent<NumberWindow> ().value = leftscore;
		GameObject.Find ("NumberWindowR").GetComponent<NumberWindow> ().value = rightscore;
		if (!waitforgame) {
			waitforgame = true;

			GameObject og = GameObject.Instantiate (onegame);
			ongoing = og.GetComponent<TUIGame> ();

			leftw.GetComponent<SpriteRenderer> ().color = Random.ColorHSV(0, 1, 0.5f, 1);
			rightw.GetComponent<SpriteRenderer> ().color = Random.ColorHSV(0, 1, 0.5f, 1);

			ongoing.leftWiz = leftw;
			ongoing.rightWiz = rightw;



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
