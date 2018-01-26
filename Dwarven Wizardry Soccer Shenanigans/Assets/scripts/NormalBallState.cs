using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBallState : BallState {

	public NormalBallState(Ball b) : base(b){
		canreach = true;
	}

	public override void Update () {
		
	}
}
