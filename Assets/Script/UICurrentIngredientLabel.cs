using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrentIngredientLabel : MonoBehaviour {

    private UILabel label;
    private PlayerMeal playerMeal;

    // Use this for initialization
    void Start () {
        label = GetComponent<UILabel>();
        label.text = "";
        playerMeal = GameSystemManager.GetInstance().playerMeal;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonUp(0)) {

	        string str = "";

	        for (int i = 0; i < playerMeal.currentIngredients.Count; i++) {
	            BaseIngredient ingredient = playerMeal.currentIngredients[i] as BaseIngredient;

	            str += ingredient.i_name + '\n';

	        }

	        label.text = str;

	    }

	}
}
