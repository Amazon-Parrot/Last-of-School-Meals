using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeal : BaseMeal {

	public ArrayList currentIngredients;
	public BaseMeal targetMeal;

	// Use this for initialization
	void Start () {
		currentIngredients = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddIngredient(BaseIngredient ingredient){
		currentIngredients.Add(ingredient);
	}
}
