using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUIGame : MonoBehaviour {

	public GameObject poof;
	public GameObject ball;
	public GameObject ballshadow;

	public GameObject leftWiz;
	public GameObject rightWiz;

	public GameController leftc;
	public GameController rightc;

	public AbilityWindow lefta;
	public AbilityWindow righta;

	public float wizardSpeed;

	private float start;
	public float waitime;

	private bool instantiated = false;
	public bool finished = false;
	public int winner = 1;

	// Use this for initialization
	void Start () {

		GameObject man = GameObject.Find ("Manager");
		MVPManager mvp = man.GetComponent<MVPManager> ();
		leftc = mvp.leftc.GetComponent<GameController> ();
		rightc =  mvp.rightc.GetComponent<GameController> ();

		lefta = GameObject.Find ("AbilityWindowL").GetComponent<AbilityWindow> ();
		righta = GameObject.Find ("AbilityWindowR").GetComponent<AbilityWindow> ();

		start = Time.time;
	}

	public void End(int winned){
		finished = true;
		winner = winned;
	}

	public void Kill(){
		GameObject.Instantiate (poof, leftWiz.transform.position, Quaternion.identity);
		Destroy (leftWiz);
		GameObject.Instantiate (poof, rightWiz.transform.position, Quaternion.identity);
		Destroy (rightWiz);
		GameObject.Instantiate (poof, ball.transform.position, Quaternion.identity);
		Destroy (ball);
		Destroy (ballshadow);
		foreach (GameObject ru in GameObject.FindGameObjectsWithTag("Rune")) {
			Destroy (ru);
		}
		foreach (GameObject de in GameObject.FindGameObjectsWithTag("DestroyOnEnd")) {
			Destroy (de);
		}


		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (!instantiated) {
			if (Time.time > start + waitime) {

				instantiated = true;
				leftWiz = GameObject.Instantiate (leftWiz, new Vector3 (-5, -3, 0), Quaternion.identity);
				GameObject.Instantiate (poof, new Vector3 (-5, -3, 0), Quaternion.identity);
				rightWiz = GameObject.Instantiate (rightWiz, new Vector3 (5, -3, 0), Quaternion.identity);
				GameObject.Instantiate (poof, new Vector3 (5, -3, 0), Quaternion.identity);

				leftWiz.GetComponent<Wizard>().speedCompensation = this.wizardSpeed;
				rightWiz.GetComponent<Wizard>().speedCompensation = this.wizardSpeed;

				ball = GameObject.Instantiate (ball, new Vector3 (0, -3, 0), Quaternion.identity);
				GameObject.Instantiate (poof, new Vector3 (0, -3, 0), Quaternion.identity);
				ballshadow = GameObject.Instantiate (ballshadow, new Vector3 (0, -3, 0), Quaternion.identity).GetComponent<BallShadow> ().ball = ball;

				Wizard lwi = leftWiz.GetComponent<Wizard> ();
				Wizard rwi = rightWiz.GetComponent<Wizard> ();

				lwi.teamtag = 1;
				rwi.teamtag = 2;

				leftc.controled = lwi;
				rightc.controled = rwi;

				lefta.wiz = lwi;
				righta.wiz = rwi;



			}
		}
	}
}
