﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBasic : BasicAbility {

	public DeathBasic(Wizard w) : base(w){
		cooldown = 2f;
		castduration = 0.5f;
		effect = (GameObject)Resources.Load ("necromancer_basic");
		radius = 1.4f;
		intensity = 4;
		amortice = 0.5f;
		distance_modifier = 1f;
		logo = findlogo("abilty_icons_death_2");
	}
}
