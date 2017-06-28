using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemManager : MonoBehaviour {

    public PlayerMeal playerMeal;

    private static GameSystemManager instance;
    public static GameSystemManager GetInstance() {
        if (!instance) {
            instance = (GameSystemManager) GameObject.FindObjectOfType(typeof(GameSystemManager));
            if (!instance)
                Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
        }

        return instance;
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickedIngredient(BaseIngredient ingredient) {
        
        if (!playerMeal.AddIngredient(ingredient)){
            playerMeal.DeleteIngredient(ingredient);
        }

        playerMeal.UpdateIngredients();
    }

    public void ClickedTargetMeal(BaseMeal meal) {
        playerMeal.targetMeal = meal;
        playerMeal.UpdateIngredients();
    }
}
