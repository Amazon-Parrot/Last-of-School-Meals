using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTasty : MonoBehaviour {

    [Range(-1, 10)]
    public float t_salty = 5;
    [Range(-1, 10)]
    public float t_spaicy = 5;
    [Range(-1, 10)]
    public float t_sourly = 5;
    [Range(-1, 10)]
    public float t_moisture = 5;
    [Range(-1, 10)]
    public float t_healthy = 5;

    public string[] t_debuff  = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void SetDebuff(string buf)
    //{
    //    t_debuff.Add(buf);
    //}


    public string GetDebuff(int index)
    {
        return t_debuff[index];
    }


    public int GetDebuffSize()
    {
        return t_debuff.Length;
    }
}
