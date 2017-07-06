using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtResultScene : MonoBehaviour {

    public int IngredientsMinimum;
    public GameObject label;

    private float DeltaTime;
    private bool asdf;

	// Use this for initialization
	void Start () {
	    DeltaTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (asdf) {
	        DeltaTime += Time.deltaTime;
	        if (DeltaTime > 1) {
	            asdf = false;
	            DeltaTime = 0;
                label.SetActive(false);
	        }
	    }
	}

    void OnClick() {
        if (GameSystemManager.GetInstance().playerMeal.currentIngredients.Count >= IngredientsMinimum) {
            GameSystemManager.GetInstance().isResult = true;
        }
        else {
            label.SetActive(true);
            label.GetComponent<UILabel>().text = "양심적으로 " + IngredientsMinimum + "개는 재료로 넣자!";
            label.GetComponent<TweenScale>().Reset();
            label.GetComponent<TweenScale>().enabled = true;
            asdf = true;
            DeltaTime = 0;
        }
    }
}
