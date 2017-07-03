using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerMealLabel : MonoBehaviour {
    
    private UILabel label;
    private PlayerMeal playerMeal;


	// Use this for initialization
	void Start () {
	    label = GetComponent<UILabel>();
	    label.text = "";
	    playerMeal = GameSystemManager.GetInstance().playerMeal;
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetMouseButtonUp(0)) {

	        if (playerMeal.currentIngredients.Count <= 0) {
                label.text = "";
                return;
	        }

            string str = "";

            //짠거
            if (playerMeal.t_salty >= 7) {
                if (playerMeal.t_salty >= 9) {
                    str += "완전 짠데?\n";
                }
                else {
                    str += "좀 짤거 같아.\n";
                }
            }else if (playerMeal.t_salty <= 3) {
                str += "흠, 싱거울거 같군.\n";
            }

            //신거
            if (playerMeal.t_sourly >= 7) {
                if (playerMeal.t_sourly >= 9) {
                    str += "셔! 셔!\n";
                }
                else {
                    str += "상큼한 맛이겠군.\n";
                }
            }

            //건강
            if (playerMeal.t_healthy >= 9) {
                str += "건강해지는 맛이야!\n";
            }

            //매워
            if (playerMeal.t_spaicy >= 7) {
                if (playerMeal.t_spaicy >= 9) {
                    str += "맵다 매우 맵다!\n";
                }
                else {
                    str += "살짝 매콤한 맛이겠어\n";
                }
            }


            label.text = str;
	    }

	}
}
