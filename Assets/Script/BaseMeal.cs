﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Recipe {Raw, Boil, Fry, CoolDown};

public class BaseMeal : BaseTasty {

	public Recipe m_recipe;
    public string m_name;

    public bool isHide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
