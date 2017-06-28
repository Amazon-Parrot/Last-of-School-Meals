using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Recipe {Raw, Boil, Fry, CoolDown};

public class BaseMeal : BaseTasty {

	public Recipe m_recipe;
    public string m_name;

    public bool isHide;

    [HideInInspector]
    public BaseIngredient[] MustHave;

    [HideInInspector]
    public BaseIngredient[] MustNotHave;

    // Use this for initialization
    void Start () {
        IngredientMustHave mustHave = GetComponent<IngredientMustHave>();
        IngredientMustNotHave mustNotHave = GetComponent<IngredientMustNotHave>();

        if (mustHave != null) {
            MustHave = new BaseIngredient[mustHave.ingredients.Length];

            for (int i = 0; i < MustHave.Length; i++) {
                MustHave[i] = mustHave.ingredients[i].GetComponent<BaseIngredient>();
            }

        }

        if (mustNotHave != null) {
            MustNotHave = new BaseIngredient[mustNotHave.ingredients.Length];

            for (int i = 0; i < MustNotHave.Length; i++) {
                MustNotHave[i] = mustNotHave.ingredients[i].GetComponent<BaseIngredient>();
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
