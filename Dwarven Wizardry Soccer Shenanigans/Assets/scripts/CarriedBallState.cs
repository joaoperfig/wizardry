using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriedBallState : BallState {

	public CarriedBallState(Ball b) : base(b){
		canreach = false;
	}

	public override void Update () {
		ball.gameObject.transform.position = new Vector3 (99, 99, 0);
		ball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}
}
