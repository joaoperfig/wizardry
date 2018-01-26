using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallState {
	public Ball ball;

	public bool canreach;

	public BallState(Ball b) {
		ball = b;
	}


	// Update is called once per frame
	public virtual void Update () {
		
	}
}
