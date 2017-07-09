using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerSick : MonoBehaviour {
    public TotalMealScore mealScore;
    public GameObject label;

    private UISprite sprite;
    private UILabel uiLabel;

    private float DeltaTime;

    private string[] resultString = null;
    private int resultStringAnimationIndex = 0;
    public bool isResultPrintEnded = false;

    private bool isCleared = false;

	// Use this for initialization
	void Start () {
	    sprite = GetComponent<UISprite>();
	    uiLabel = label.GetComponent<UILabel>();
	    uiLabel.text = "";
	    DeltaTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    DeltaTime += Time.deltaTime;

	    if (DeltaTime > 1f && resultString == null) {
	        resultString = AnalysisMealWithLabel().Split('\n');
	    }

	    if (DeltaTime > 1.7f) {
	        sprite.spriteName = ((int)(DeltaTime/0.3f)%2 != 0 ? "2" : "1");

	    }

	    if (!isResultPrintEnded && DeltaTime > 2.4f + resultStringAnimationIndex) {
	        if (resultStringAnimationIndex < resultString.Length) {
	            resultStringAnimationIndex++;
                uiLabel.text += resultString[resultStringAnimationIndex - 1] + '\n';
            }
	        else {
                isResultPrintEnded = true;
	        }

	    }

	}

    string AnalysisMealWithLabel() {
        string str = "";

        if (mealScore.totalTasty < 0.2f) {
            str = SetER(str);
            str += "내가 생각하던 바로 그 맛이야!!!!\n드디어 성공했";
            isCleared = true;
        }
        else {

            //짠정도
            if (mealScore.salty > 0.5) {

                if (mealScore.salty > 3) {
                    str = SetER(str);
                    str += "미친 완전 짜";
                }
                else {
                    str = SetER(str);
                    str += "조금 짜";
                }
            }
            else if(mealScore.salty < -0.5 && mealScore.salty > -9999) {
                if (mealScore.salty < -3) {
                    str = SetER(str);
                    str += "엄청나게 싱겁";
                }
                else {
                    str = SetER(str);
                    str += "음, 좀 싱겁";
                }
            }

            //매운정도
            if (mealScore.spaicy > 0.5) {

                if (mealScore.spaicy > 3) {
                    str = SetER(str);
                    str += "한국인을 능가하는 매운 맛이";
                }
                else {
                    str = SetER(str);
                    str += "조금 맵";
                }
            }
            else if (mealScore.spaicy < -0.5 && mealScore.spaicy > -9999) {
                if (mealScore.spaicy < -3) {
                    str = SetER(str);
                    str += "전혀 1도 안맵";
                }
                else {
                    str = SetER(str);
                    str += "생각보다 안맵";
                }
            }

            //신정도
            if (mealScore.sourly > 0.5) {

                if (mealScore.sourly > 3) {
                    str = SetER(str);
                    str += "완전 신거 실화인지 궁금하";
                }
                else {
                    str = SetER(str);
                    str += "약간 새콤하";
                }
            }
            else if (mealScore.sourly < -0.5 && mealScore.sourly > -9999) {
                if (mealScore.sourly < -3) {
                    str = SetER(str);
                    str += "그냥 아예 신맛이 정지했";
                }
                else {
                    str = SetER(str);
                    str += "좀 새콤했으면 좋겠";
                }
            }


            //촉촉한정도
            if (mealScore.moisture > 0.5) {

                if (mealScore.moisture > 3) {
                    str = SetER(str);
                    str += "누가보면 물밖에 없다고 할 정도이";
                }
                else {
                    str = SetER(str);
                    str += "생각보다 좀 축축한거 같";
                }
            }
            else if (mealScore.moisture < -0.5 && mealScore.moisture > -9999) {
                if (mealScore.moisture < -3) {
                    str = SetER(str);
                    str += "가뭄이 왜 음식에서도 일어나는지 궁금하";
                }
                else {
                    str = SetER(str);
                    str += "생각보다 약간 건조한거 같";
                }
            }


            //건강한 정도
            if (mealScore.healthy > 0.5) {

                if (mealScore.healthy > 3) {
                    str = SetER(str);
                    str += "이거 먹으면 건강해져서 100년은 끄떡없겠";
                }
                else {
                    str = SetER(str);
                    str += "음식이 좀 유기농 슬로우 푸드의 느낌이 적잖아 있";
                }
            }
            else if (mealScore.healthy < -0.5 && mealScore.healthy > -9999) {
                if (mealScore.healthy < -3) {
                    str = SetER(str);
                    str += "악마의 음식처럼 먹으면 암이 생길거 같";
                }
                else {
                    str = SetER(str);
                    str += "좀 더 건강한 느낌을 살리고 싶";
                }
            }


            //필수요소
            if (!mealScore.isMustUseCorrect) {
                str = SetER(str);
                str += "꼭 들어가야할 재료가 좀 빠진거 같";
            }


            //안필수요소
            if (!mealScore.isMustNotUseCorrect){
                str = SetER(str);
                str += "넣으면 안되는 재료가 들어있";
            }

            if (!mealScore.isRecipeCorrect) { 
                str = SetER(str);
                str += "조리법이 이상하";
            }

        }


        if (str == "") {
            str = SetER(str);
            str += "내가 생각하던 맛인데...\n뭔가 조금 안타깝군..\n그래도 만족할 정도";
        }

        var r = new System.Random();
        str += (r.Next(2) == 0) ? "군.." : "다..";

        if(!isCleared)
            str += "\n\n좋아, 요시! 다시 한번 해보자!";

        Debug.Log(str);
        return str;
    }


    private string SetER(string str) {
        if (str == "") {
            return "이 음식은...\n";
        }

        return str + "고 \n";
    }
}
