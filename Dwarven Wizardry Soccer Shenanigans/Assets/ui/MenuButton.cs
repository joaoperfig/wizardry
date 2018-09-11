using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, ISelectHandler , IPointerEnterHandler, IPointerDownHandler{

	private MenuPanel mymenu;
	public ButtonAction action;
	private bool highlighted = false;

	void Start(){
		mymenu = gameObject.transform.parent.gameObject.GetComponent<MenuPanel> ();
	}

	// When highlighted with mouse.
	public void OnPointerEnter(PointerEventData eventData){
		highlighted = true;
		mymenu.wasHovered (this);
		Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
	}
	// When selected.
	public void OnSelect(BaseEventData eventData){
		highlighted = false;
		Debug.Log("<color=red>Event:</color> Completed selection.");
	}

	public void OnPointerDown(PointerEventData eventData){
		Debug.Log("Button Pressed!");
		mymenu.clickedButt (this);
	}

	public void doStuff(){
		Debug.Log ("action");
		action.action ();
	}
}