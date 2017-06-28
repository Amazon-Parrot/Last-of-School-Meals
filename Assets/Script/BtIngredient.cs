using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtIngredient : MonoBehaviour {

    public BaseIngredient Ingredient;

    private UILabel label;

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
        }

        label.text = Ingredient.i_name;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick() {
        GameSystemManager.GetInstance().ClickedIngredient(Ingredient);
    }
}
