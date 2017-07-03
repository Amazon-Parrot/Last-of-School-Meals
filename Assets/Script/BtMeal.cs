using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtMeal : MonoBehaviour {

    public BaseMeal meal;

    private UILabel label;
    private UISprite sprite;

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

        label.text = meal.m_name;
        sprite.spriteName = meal.m_spriteName;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnClick() {
        GameSystemManager.GetInstance().ClickedTargetMeal(meal);
        GameSystemManager.GetInstance().isSelectedMeal = true;
    }
}
