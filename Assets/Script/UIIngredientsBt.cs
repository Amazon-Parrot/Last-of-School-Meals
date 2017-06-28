using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIngredientsBt : MonoBehaviour {

    public GameObject Ingredients;
    public GameObject ButtonIngredient;


    private float mousePosX;

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

	    if (Input.GetMouseButtonDown(0)) {
	        mousePosX = Input.mousePosition.x;
	    }

	    if (Input.GetMouseButton(0)) {
            if (Input.mousePosition.y <= Screen.height/3) {
                transform.localPosition = transform.localPosition + new Vector3(Input.mousePosition.x - mousePosX, 0, 0);
                mousePosX = Input.mousePosition.x;

            }
        }

	}
}
