using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterControl : MonoBehaviour
{
	public GameObject p1,p2;
	
    // Start is called before the first frame update
    void Start()
    {
		var systems = GetComponentsInChildren<ParticleSystem>();
		foreach(var system in systems){
			var emission = system.emission;
			emission.enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
		var systems = GetComponentsInChildren<ParticleSystem>();
		//Debug.Log(p1.transform.localPosition.y+" "+p2.transform.localPosition.y);
        if(p1.transform.position.y<p2.transform.position.y){
			foreach(var system in systems){
				var emission = system.emission;
				emission.enabled = true;
			}
		}
		else{
			foreach(var system in systems){
				var emission = system.emission;
				emission.enabled = false;
			}
		}
    }
}
