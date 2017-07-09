using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtIngredient : MonoBehaviour {

    public BaseIngredient Ingredient;
    public GameObject IngredientObjectsParent;

    private UILabel label;
    private UISprite sprite;

    private GameObject ingredientGameObject = null;

    // Use this for initialization
    void Start () {
    }

    public void Init() {
        for (var i = 0; i < transform.childCount; i++) {
            var tmp = transform.GetChild(i).gameObject;

            if (tmp.transform.name == "Label") {
                label = tmp.GetComponent<UILabel>();
                continue;
            }

            if (tmp.transform.name == "Background") {
                sprite = tmp.GetComponent<UISprite>();
                continue;
            }
        }

        label.text = Ingredient.i_name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick() {
        if (GameSystemManager.GetInstance().ClickedIngredient(Ingredient)) {
            ingredientGameObject = Instantiate(GameObject.Find("IngredientSprite"), IngredientObjectsParent.transform);
            ingredientGameObject.transform.localPosition = Vector3.zero;
        }
        else {
            Destroy(ingredientGameObject);
            ingredientGameObject = null;
        }
    }
}
