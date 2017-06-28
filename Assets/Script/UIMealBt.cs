using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMealBt : MonoBehaviour {

    public GameObject Meals;
    public GameObject ButtonMeal;

    // Use this for initialization
    void Start() {
        for (var i = 0; i < Meals.transform.childCount; i++) {
            var tmp = Meals.transform.GetChild(i).gameObject;

            if (tmp.GetComponent<BaseMeal>().isHide) {
                continue;
            }
            GameObject bt = Instantiate(ButtonMeal, transform);
            bt.transform.localPosition = new Vector3(-496 + 200 * i, 232, 0);
            var attr = bt.GetComponent<BtMeal>();

            attr.meal = tmp.GetComponent<BaseMeal>();
            attr.Init();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
