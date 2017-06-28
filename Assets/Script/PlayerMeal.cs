using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeal : BaseMeal {

	public ArrayList currentIngredients;
	public BaseMeal targetMeal;

	// Use this for initialization
	void Start () {
		currentIngredients = new ArrayList();

	    t_salty = 0;
	    t_healthy = 0;
	    t_moisture = 0;
	    t_sourly = 0;
	    t_spaicy = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateIngredients() {

        t_salty = t_healthy = t_moisture = t_sourly = t_spaicy = 0;

        int count_salty = 0;
        int count_healthy = 0;
        int count_moisture = 0;
        int count_sourly = 0;
        int count_spaicy = 0;

        for (int i = 0; i < currentIngredients.Count; i++) {
            BaseIngredient ingredient = currentIngredients[i] as BaseIngredient;

            if (ingredient.t_salty >= 0) {
                t_salty += ingredient.t_salty;
                count_salty++;
            }

            if (ingredient.t_healthy >= 0) {
                t_healthy += ingredient.t_healthy;
                count_healthy++;
            }

            if (ingredient.t_moisture >= 0) {
                t_moisture += ingredient.t_moisture;
                count_moisture++;
            }

            if (ingredient.t_sourly >= 0) {
                t_sourly += ingredient.t_sourly;
                count_sourly++;
            }

            if (ingredient.t_spaicy >= 0) {
                t_spaicy += ingredient.t_spaicy;
                count_spaicy++;
            }

        }

        if(count_salty != 0)
            t_salty /= count_salty;
        if (count_healthy != 0)
            t_healthy /= count_healthy;
        if (count_moisture != 0)
            t_moisture /= count_moisture;
        if (count_sourly != 0)
            t_sourly /= count_sourly;
        if (count_spaicy != 0)
            t_spaicy /= count_spaicy;
    }

	public bool AddIngredient(BaseIngredient ingredient){
        
        if (FindIngredient(ingredient.i_name) < 0) {
	        currentIngredients.Add(ingredient);
	        return true;
	    }
        return false;
	}

    public void DeleteIngredient(BaseIngredient ingredient) {
        for (int i = 0; i < currentIngredients.Count; i++) {
            BaseIngredient _ingredient = currentIngredients[i] as BaseIngredient;

            if (ingredient.i_name == _ingredient.i_name) {
                currentIngredients.RemoveAt(i);
            }
        }
    }

    public void DeleteIngredient(int index) {
        currentIngredients.RemoveAt(index);
    }

    public int FindIngredient(string name) {
        for (int i = 0; i < currentIngredients.Count; i++) {
            BaseIngredient ingredient = currentIngredients[i] as BaseIngredient;

            if (ingredient.i_name == name) {
                return i;
            }
        }

        return -1;
    }
}
