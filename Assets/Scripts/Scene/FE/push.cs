using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	public GameObject waterp;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		int pushtrue = waterp.GetComponent<WaterCheck>().pushtrue;
        if(Input.GetKeyDown(KeyCode.Space)&&pushtrue==0){
			pushtrue=1;
		}
		else if(Input.GetKeyUp(KeyCode.Space)&&pushtrue==1){
			pushtrue=0;
		}
			
    }
}
