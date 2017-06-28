using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIngredientsBt : MonoBehaviour {

    public GameObject Ingredients;
    public GameObject ButtonIngredient;

	// Use this for initialization
	void Start () {
        for (var i = 0; i < Ingredients.transform.childCount; i++) {
            var tmp = Ingredients.transform.GetChild(i).gameObject;

            GameObject bt = Instantiate(ButtonIngredient, transform);
            bt.transform.localPosition = new Vector3(-530 + 200 * i, -148, 0);
            var attr = bt.GetComponent<BtIngredient>();

            attr.Ingredient = tmp.GetComponent<BaseIngredient>();
            attr.Init();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
