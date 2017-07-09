using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TotalMealScore {
    public float salty;
    public float spaicy;
    public float sourly;
    public float moisture;
    public float healthy;

    public float totalTasty;

    public bool isRecipeCorrect;
    public bool isDebuffCorrect;
    public bool isMustUseCorrect;
    public bool isMustNotUseCorrect;
}

public class GameSystemManager : MonoBehaviour {

    public PlayerMeal playerMeal;

    private GameObject mealPanel;
    private GameObject cookPanel;
    private GameObject recipePanel;
    private GameObject resultPanel;

    public bool isSelectedMeal;
    public bool isResult = false;
    public bool isRecipe = false;

    public TotalMealScore TotalResultMealScore;

    private static GameSystemManager instance;
    public static GameSystemManager GetInstance() {
        if (!instance) {
            instance = (GameSystemManager) GameObject.FindObjectOfType(typeof(GameSystemManager));
            if (!instance)
                Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
        }

        return instance;
    }


	// Use this for initialization
	void Start () {
	    mealPanel = GameObject.Find("MealPanel");
	    cookPanel = GameObject.Find("CookPanel");
        recipePanel = GameObject.Find("RecipePanel");
        resultPanel = GameObject.Find("ResultPanel");

        cookPanel.SetActive(false);
        resultPanel.SetActive(false);
        recipePanel.SetActive(false);
	    isSelectedMeal = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!cookPanel.activeInHierarchy && isSelectedMeal) {
	        cookPanel.SetActive(true);
            mealPanel.SetActive(false);
	        isSelectedMeal = false;
	    }

	    if (isRecipe && !recipePanel.activeInHierarchy) {
            cookPanel.SetActive(false);
            recipePanel.SetActive(true);
	        isRecipe = false;

	    }

        if (isResult && !resultPanel.activeInHierarchy) {
            recipePanel.SetActive(false);
            resultPanel.SetActive(true);

	        TotalResultMealScore = AnalysisMeal();

            Debug.Log("salty = " + TotalResultMealScore.salty);
            Debug.Log("spaicy = " + TotalResultMealScore.spaicy);
            Debug.Log("sourly = " + TotalResultMealScore  .sourly);
            Debug.Log("moisture = " + TotalResultMealScore.moisture);
            Debug.Log("healthy = " + TotalResultMealScore .healthy);
            Debug.Log("맛 오차 = " + TotalResultMealScore .totalTasty);
            Debug.Log("조리법 맞음 = " + TotalResultMealScore.isRecipeCorrect);
            Debug.Log("디버프 여부 : " + TotalResultMealScore.isDebuffCorrect);
            Debug.Log("필수요소 여부 : " + TotalResultMealScore.isMustUseCorrect);
            Debug.Log("필수밴요소 여부 : " + TotalResultMealScore.isMustNotUseCorrect);

	        GameObject.Find("ResultPlayerSprite").GetComponent<UIPlayerSick>().mealScore = TotalResultMealScore;
	    }
	}

    public bool ClickedIngredient(BaseIngredient ingredient) {

        bool returnValue = playerMeal.AddIngredient(ingredient);
        
        if (!returnValue){
            playerMeal.DeleteIngredient(ingredient);
        }

        playerMeal.UpdateIngredients();

        return returnValue;
    }

    public void ClickedTargetMeal(BaseMeal meal) {
        playerMeal.targetMeal = meal;
        playerMeal.UpdateIngredients();
    }

    private TotalMealScore AnalysisMeal() {
        TotalMealScore totalScore = new TotalMealScore();
        int totalTastyCount = 0;
        float totalTastyValue = 0;
        //짠맛
        if (playerMeal.targetMeal.t_salty == -1) {
            totalScore.salty = -99999;
        }
        else {
            totalScore.salty = playerMeal.t_salty - playerMeal.targetMeal.t_salty;
            totalTastyValue += Mathf.Abs(totalScore.salty);
            totalTastyCount++;
        }
        //신맛
        if (playerMeal.targetMeal.t_sourly == -1) {
            totalScore.sourly = -99999;
        }
        else {
            totalScore.sourly = playerMeal.t_sourly - playerMeal.targetMeal.t_sourly;
            totalTastyValue += Mathf.Abs(totalScore.sourly);
            totalTastyCount++;
        }
        //매운맛
        if (playerMeal.targetMeal.t_spaicy == -1) {
            totalScore.spaicy = -99999;
        }
        else {
            totalScore.spaicy = playerMeal.t_spaicy - playerMeal.targetMeal.t_spaicy;
            totalTastyValue += Mathf.Abs(totalScore.spaicy);
            totalTastyCount++;
        }
        //수분
        if (playerMeal.targetMeal.t_moisture == -1) {
            totalScore.moisture = -99999;
        }
        else {
            totalScore.moisture = playerMeal.t_moisture - playerMeal.targetMeal.t_moisture;
            totalTastyValue += Mathf.Abs(totalScore.moisture);
            totalTastyCount++;
        }
        //건강도
        if (playerMeal.targetMeal.t_healthy == -1) {
            totalScore.healthy = -99999;
        }
        else {
            totalScore.healthy = playerMeal.t_healthy - playerMeal.targetMeal.t_healthy;
            totalTastyValue += Mathf.Abs(totalScore.healthy);
            totalTastyCount++;
        }

        totalScore.totalTasty = totalTastyValue / totalTastyCount;

        totalScore.isDebuffCorrect = playerMeal.currentDebuff.Count <= 0;
        totalScore.isRecipeCorrect = playerMeal.m_recipe == playerMeal.targetMeal.m_recipe;

        totalScore.isMustUseCorrect = true;
        for (int i = 0; i < playerMeal.targetMeal.MustHave.Length; i++) {
            BaseIngredient ingredient = playerMeal.targetMeal.MustHave[i];
            int index = playerMeal.FindIngredient(ingredient.i_name);

            if (index < 0) {
                totalScore.isMustUseCorrect = false;
                break;
            }
        }

        totalScore.isMustNotUseCorrect = true;
        for (int i = 0; i < playerMeal.targetMeal.MustNotHave.Length; i++) {
            BaseIngredient ingredient = playerMeal.targetMeal.MustNotHave[i];
            int index = playerMeal.FindIngredient(ingredient.i_name);

            if (index > -1) {
                totalScore.isMustNotUseCorrect = false;
                break;
            }
        }


        return totalScore;
    }
}
