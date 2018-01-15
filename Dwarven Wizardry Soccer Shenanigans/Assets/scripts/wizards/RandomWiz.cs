using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWiz : MonoBehaviour {

	private Color color;

	// Use this for initialization
	void Start () {
		color = Random.ColorHSV(0, 1, 0.7f, 1, 0.8f, 1);
		gameObject.GetComponent<SpriteRenderer> ().color = color;
		gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().color = color;

		Wizard lewi = gameObject.GetComponent<Wizard> ();
		lewi.abilities = new Ability[4];
		lewi.abilities [0] = new Ability[4] {new BasicAbility(lewi), new RuneBasic(lewi), new ShadowBasic(lewi), new ForceBasic(lewi)} [Random.Range (0, 4)];
		lewi.abilities [1] = new Ability[4] {new FireSpeed(lewi), new ShadowJump(lewi), new ForceDash(lewi), new RuneTeleport(lewi)} [Random.Range (0, 4)];
		lewi.abilities [2] = new Ability[8] {new SmallFireBall(lewi), new BigFireBall(lewi), new ForceBall(lewi), new ForcePull(lewi), new RuneExplode(lewi), new RuneImplode(lewi), new ShadowPossession(lewi), new ShadowSwap(lewi)} [Random.Range (0, 8)];
		lewi.abilities [3] = new Ability[8] {new SmallFireBall(lewi), new BigFireBall(lewi), new ForceBall(lewi), new ForcePull(lewi), new RuneExplode(lewi), new RuneImplode(lewi), new ShadowPossession(lewi), new ShadowSwap(lewi)} [Random.Range (0, 8)];

		
	}
	

}
