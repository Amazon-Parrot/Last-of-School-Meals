using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICurrentMeal : MonoBehaviour {

    private UISprite sprite;
    private bool isInit;

	// Use this for initialization
	void Start () {
	    sprite = GetComponent<UISprite>();
        
    }

    // Update is called once per frame
    void Update () {
        if (!isInit) {
            sprite.spriteName = GameSystemManager.GetInstance().playerMeal.targetMeal.m_spriteName;
            isInit = true;
        }
	}
}
