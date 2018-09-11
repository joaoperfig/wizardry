using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour {

	private List<MenuButton> buttons;
	private int blen;
	private int chosen = 0;
	public GameObject selector;
	private bool selectorinstantiated = false;
	public bool active;

	// Use this for initialization
	void Start () {
		buttons = new List<MenuButton> ();
		foreach (Transform child in gameObject.transform) {
			buttons.Add (child.gameObject.GetComponent<MenuButton> ());
		}
		blen = buttons.Count;
		updateSelector ();
	}

	public void updateSelector(){
		if (!selectorinstantiated) {
			selector = GameObject.Instantiate (selector, gameObject.transform);
			selectorinstantiated = true;
		}
		Vector3 newpos = selector.transform.localPosition;
		newpos.y = buttons [chosen].transform.localPosition.y;
		selector.transform.localPosition = newpos;
	}

	public void wasHovered(MenuButton butt){
		if (active) {
			chosen = findButt (butt);
			updateSelector ();
		}
	}

	public int findButt(MenuButton butt){
		for (int i = 0; i < blen; i++) {
			if (butt == buttons [i]) {
				return i;
			}
		}
		Debug.Log ("Button was not found!");
		return 0;
	}

	public void clickedButt(MenuButton butt){
		if (active) {
			if (!(findButt (butt) == chosen)) {
				Debug.Log ("WARNING, CLICKED BUTTON WAS NOT CHOSEN!");
			}
			butt.doStuff ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
				chosen = chosen + 1;
				if (chosen == blen)
					chosen = 0;
				updateSelector ();
			}
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
				chosen = chosen - 1;
				if (chosen < 0)
					chosen = blen-1;
				updateSelector ();
			}
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter) || Input.GetKeyDown (KeyCode.Space)) {
				clickedButt(buttons[chosen]);
			}
		}		
	}
}
