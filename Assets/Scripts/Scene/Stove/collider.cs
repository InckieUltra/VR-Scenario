using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collider : MonoBehaviour
{
	public GameObject fire;
	bool oil;
    // Start is called before the first frame update
    void Start()
    {
		oil = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision){
		string s = collision.collider.gameObject.name;
		Debug.Log(s);
		if(s == "Cap"){
			fire.GetComponent<ParticleControl>().rate -= 30;
		}
		if(s == "Mushrooms"){
			fire.GetComponent<ParticleControl>().rate -= 10;
		}
		if(s == "oil"&&!oil){
			if(fire.GetComponent<ParticleControl>().rate > 0)
				fire.GetComponent<ParticleControl>().rate *= 2;
			oil = true;
		}
		if(s == "water"||s=="water1"||s=="water2"){
			SceneManager.LoadScene("StoveWaterFail");
		}
		if(s == "Powder0"||s=="Powder1"||s=="Powder2"){
			SceneManager.LoadScene("StovePowderFail");
		}
	}
	
	void OnCollisionExit(Collision collision){
		string s = collision.collider.gameObject.name;
		Debug.Log(s);
		if(s == "Cap"){
			fire.GetComponent<ParticleControl>().rate *= 2;
		}
		
		
	}
}
