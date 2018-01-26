using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStrategyController : GameController {
	public GameObject ball;
	public AIStrat[] strategies;

	public bool lastup = false;
	public bool lastdown = false;
	public bool lastleft = false;
	public bool lastright = false;
	public bool nowup = false;
	public bool nowdown = false;
	public bool nowleft = false;
	public bool nowright = false;

	public AIStrategyController() : base(){

	}

	public override void check() {
		strategies = new AIStrat[6] { new AIStratDefend (controled, this),
									  new AIStratAttack(controled, this), 
			                          new ASBasicKick(controled, this, controled.abilities[0], 1),
			                          new ASRandom (controled, this, controled.abilities[1], 2),
									  new ASRandom (controled, this, controled.abilities[2], 3),
									  new ASRandom (controled, this, controled.abilities[3], 4),
		                              };
		float minheur = 9999;
		AIStrat strategy = strategies[0];
		foreach (AIStrat strat in strategies) {
			float heur = strat.negativeHeuristic ();
			if (heur < minheur) {
				minheur = heur;
				strategy = strat;
			}
		}
		strategy.control ();
		updateLatent ();
	}

	public void latentup(){nowup = true;if (lastup) up ();}
	public void latentdown(){nowdown = true;if (lastdown) down ();}
	public void latentleft(){nowleft = true;if (lastleft) left ();}
	public void latentright(){nowright = true;if (lastright) right ();}

	public void updateLatent (){  // latent buttons need to be triggered on two consecutive frames to be noted;
		lastup = nowup;
		lastdown = nowdown;
		lastleft = nowleft;
		lastright = nowright;
		nowup = false;
		nowdown = false;
		nowleft = false;
		nowright = false;
	}
}
