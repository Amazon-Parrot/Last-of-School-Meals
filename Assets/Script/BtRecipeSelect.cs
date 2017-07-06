using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtRecipeSelect : MonoBehaviour {

    public Recipe m_recipe;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick() {
        GameSystemManager.GetInstance().playerMeal.m_recipe = m_recipe;
    }
}
