using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheck : MonoBehaviour
{
	public int pushtrue; 
	
    // Start is called before the first frame update
    void Start()
    {
        pushtrue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(-Vector3.up);
		bool grounded =  Physics.Raycast(transform.position,fwd,1);
        if (grounded)
        {
            Debug.LogError("发生了碰撞");
        }
        else {
            Debug.LogError("碰撞结束");
        }

    }
	
	/*void OnTriggerStay(Collider other){
		if(other.name=="FireI"){
			Debug.Log("111");
		}
	}*/
}
