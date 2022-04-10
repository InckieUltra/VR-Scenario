using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	public GameObject Fire;
	ParticleControl pc;
	
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        pc = Fire.GetComponent<ParticleControl>();
    }
	
	void OnCollisionEnter(Collision collision){
		if(collision.collider.gameObject.name == "vr_cartoon_hand_prefab_right"){
			this.GetComponent<Renderer>().material.color = Color.green;
			pc.rate -= 20;
		}
	}
}
