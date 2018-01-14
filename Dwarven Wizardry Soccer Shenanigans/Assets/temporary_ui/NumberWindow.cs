using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWindow : MonoBehaviour {

	private SpriteRenderer s;

	public int value = 0;

	public Sprite n0;
	public Sprite n1;
	public Sprite n2;
	public Sprite n3;
	public Sprite n4;
	public Sprite n5;
	public Sprite n6;
	public Sprite n7;
	public Sprite n8;
	public Sprite n9;

	private Sprite[] list;

	// Use this for initialization
	void Start () {
		s = gameObject.GetComponent<SpriteRenderer> ();
		list = new Sprite[10] { n0, n1, n2, n3, n4, n5, n6, n7, n8, n9 };
	}
	
	// Update is called once per frame
	void Update () {
		s.sprite = list [value];
	}
}
