using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class showaistatus : MonoBehaviour {

	public bool isleft;

	public Sprite left;
	public Sprite right;
	public Sprite mid;
	public Sprite num;
	public Sprite gany;
	public Sprite g1;
	public Sprite g2;
	public Sprite g3;
	public Sprite g4;
	public Sprite ai;

	public Sprite ganyc;
	public Sprite g1c;
	public Sprite g2c;
	public Sprite g3c;
	public Sprite g4c;

	public GameObject lcontrol;
	public GameObject rcontrol;
	public GameObject mcontrol;
	public GameObject ncontrol;
	public GameObject gpanyc;
	public GameObject gp1c;
	public GameObject gp2c;
	public GameObject gp3c;
	public GameObject gp4c;
	public GameObject aic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer> ();

		int stat;
		if (isleft)
			stat = gameObject.transform.parent.gameObject.GetComponent<TempUI> ().left;
		else stat = gameObject.transform.parent.gameObject.GetComponent<TempUI> ().right;

		switch (stat) {
		case 0:
			sr.sprite = left;
			break;
		case 1:
			sr.sprite = right;
			break;
		case 2:
			sr.sprite = mid;
			break;
		case 3:
			sr.sprite = num;
			break;
		case 4:
			sr.sprite = gany;
			if (isclicked (GamePad.Index.Any))
				sr.sprite = ganyc;
			break;
		case 5:
			sr.sprite = g1;
			if (isclicked (GamePad.Index.One))
				sr.sprite = g1c;
			break;
		case 6:
			sr.sprite = g2;
			if (isclicked (GamePad.Index.Two))
				sr.sprite = g2c;
			break;
		case 7:
			sr.sprite = g3;
			if (isclicked (GamePad.Index.Three))
				sr.sprite = g3c;
			break;
		case 8:
			sr.sprite = g4;
			if (isclicked (GamePad.Index.Four))
				sr.sprite = g4c;
			break;
		case 9:
			sr.sprite = ai;
			break;
		default:
			sr.sprite = null;
			break;
		}
	}

	bool isclicked(GamePad.Index ind){
		Vector2 dir = GamePad.GetAxis (GamePad.Axis.Dpad, ind) + GamePad.GetAxis (GamePad.Axis.LeftStick, ind) + GamePad.GetAxis (GamePad.Axis.RightStick, ind);
		return ((dir.magnitude > 0) || GamePad.GetButton (GamePad.Button.A, ind) || GamePad.GetButton (GamePad.Button.B, ind) || GamePad.GetButton (GamePad.Button.X, ind) || GamePad.GetButton (GamePad.Button.Y, ind));
	}

	public GameObject getController(){
		int stat;
		if (isleft)
			stat = gameObject.transform.parent.gameObject.GetComponent<TempUI> ().left;
		else stat = gameObject.transform.parent.gameObject.GetComponent<TempUI> ().right;

		switch (stat) {
		case 0:
			return GameObject.Instantiate(lcontrol);
			break;
		case 1:
			return GameObject.Instantiate(rcontrol);
			break;
		case 2:
			return GameObject.Instantiate(mcontrol);
			break;
		case 3:
			return GameObject.Instantiate(ncontrol);
			break;
		case 4:
			return GameObject.Instantiate(gpanyc);
			break;
		case 5:
			return GameObject.Instantiate(gp1c);
			break;
		case 6:
			return GameObject.Instantiate(gp2c);
			break;
		case 7:
			return GameObject.Instantiate(gp3c);
			break;
		case 8:
			return GameObject.Instantiate(gp4c);
			break;
		case 9:
			return GameObject.Instantiate(aic);
			break;
		default:
			return null;
			break;
		}
	}
}
