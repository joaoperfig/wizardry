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
		lewi.abilities [0] = new Ability[5] {new BasicAbility(lewi), new RuneBasic(lewi), new ShadowBasic(lewi), new ForceBasic(lewi), new TentacleBasic(lewi)} [Random.Range (0, 5)];
		lewi.abilities [1] = new Ability[5] {new FireSpeed(lewi), new ShadowJump(lewi), new ForceDash(lewi), new RuneImplode(lewi), new TentacleTrail(lewi)} [Random.Range (0, 5)];
		lewi.abilities [2] = new Ability[10] {new SmallFireBall(lewi), new BigFireBall(lewi), new ForceBall(lewi), new ForcePull(lewi), new RuneExplode(lewi), new RuneTeleport(lewi), new ShadowPossession(lewi), new ShadowSwap(lewi), new Tentacle(lewi), new TentacleGhost(lewi)} [Random.Range (0, 10)];
		lewi.abilities [3] = new Ability[10] {new SmallFireBall(lewi), new BigFireBall(lewi), new ForceBall(lewi), new ForcePull(lewi), new RuneExplode(lewi), new RuneTeleport(lewi), new ShadowPossession(lewi), new ShadowSwap(lewi), new Tentacle(lewi), new TentacleGhost(lewi)} [Random.Range (0, 10)];
		
	}
	

}
