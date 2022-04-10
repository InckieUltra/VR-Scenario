using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FEController : MonoBehaviour
{
	public Text Inst;
	public GameObject firei;
	
    // Start is called before the first frame update
    void Start()
    {
        Inst.text = "灭火器的使用\n1.拔下保险";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionExit(Collision collision){
		string s = collision.collider.gameObject.name;
		Debug.Log(s);
		if(s == "Ring"){
			Debug.Log("RingRemoved");
			Inst.text = "灭火器的使用\n2.提起灭火器 指向火源";
			collision.collider.gameObject.AddComponent<Rigidbody>();
			//firei.AddComponent<Rigidbody>();
			transform.GetComponent<Rigidbody>().freezeRotation = false;
			//transform.GetComponent<Rigidbody>().freezePosition = false;
		}
	}
	
	void OnTriggerEnter(Collider collider){
		string s = collider.gameObject.name;
		Debug.Log(s);
		if(s == "FireI"){
			Inst.text = "灭火器的使用\n3.按下把手开始灭火\n(之后的还没做完)";
		}
	}
}
