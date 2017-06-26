using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTasty : MonoBehaviour {

    public float t_salty = 5;
    public float t_spaicy = 5;
    public float t_sourly = 5;
    public float t_moisture = 5;
    public float t_healthy = 5;

	public ArrayList t_debuff  = null;
    


	// Use this for initialization
	void Start () {
		t_debuff = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDebuff(string buf)
    {
        t_debuff.Add(buf);
    }


    public string GetDebuff(int index)
    {
        return (string)t_debuff[index];
    }


    public int GetDebuffSize()
    {
        return t_debuff.Count;
    }
}
