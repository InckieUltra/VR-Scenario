using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class ParticleControl : MonoBehaviour {
 
    ParticleSystem[] ps;
    public float psScaleFloat = 0.8f;
	public float spendTime;
	public float flameLevel;
	public float rate;
	public Text textFlame;
 
	void Start(){
		spendTime=0.0f;
		flameLevel=20.0f;
		rate = 25f;
	}
 
	void Update () {
		spendTime+=Time.deltaTime;
		flameLevel+=rate*Time.deltaTime;
		textFlame.text = "flameLevel = "+((int)(flameLevel)).ToString()+"\nflameRate = "+((double)(rate)).ToString();
		foreach (var item in transform.GetComponentsInChildren<ParticleSystem>())
        {
            var main = item.main;
            main.scalingMode = ParticleSystemScalingMode.Local;
            item.transform.localScale = new Vector3(flameLevel/500, flameLevel/500, flameLevel/500);
        }
		if(flameLevel >= 500){
			SceneManager.LoadScene("StoveFail");
		}
		if(flameLevel < 0){
			SceneManager.LoadScene("StoveSuccess");
		}
	}
}