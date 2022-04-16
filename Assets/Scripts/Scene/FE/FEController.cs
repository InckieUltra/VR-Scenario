using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FEController : MonoBehaviour
{
	public Text Inst;
	public GameObject firei;
	public ParticleSystem PS;
	public ParticleSystem PS_Fire;
	private bool inrange;
	private float spendTime;
	private float flameLevel;
	
    // Start is called before the first frame update
    void Start()
    {
		transform.GetComponent<Rigidbody>().isKinematic = true;
		spendTime=0.0f;
		flameLevel=100.0f;
		inrange=false;
		PS.enableEmission=false;
        Inst.text = "灭火器的使用\n1.拔下保险";
    }

    // Update is called once per frame
    void Update()
    {
		if(flameLevel<=0)
			SceneManager.LoadScene("FEEnd");
        if (Input.GetKey(KeyCode.V))
        {
            PS.enableEmission=true;
			if(inrange){
				Inst.text = "灭火器的使用\n4.做的好 请按步骤持续喷射";
				spendTime+=Time.deltaTime;
				flameLevel-=10*Time.deltaTime;
				foreach (var item in PS_Fire.transform.GetComponentsInChildren<ParticleSystem>()){
					var main = item.main;
					main.scalingMode = ParticleSystemScalingMode.Local;
					item.transform.localScale = new Vector3(flameLevel/500, flameLevel/500, flameLevel/500);
				}
			}
        }
		if (Input.GetKeyUp(KeyCode.V))
        {
            PS.enableEmission=false;
        }
    }
	
	void OnCollisionExit(Collision collision){
		string s = collision.collider.gameObject.name;
		Debug.Log(s);
		if(s == "Ring"){
			Debug.Log("RingRemoved");
			Inst.text = "灭火器的使用\n2.提起灭火器 指向火源";
			collision.collider.gameObject.AddComponent<Rigidbody>();
			//firei.AddComponent<Rigidbody>();
			transform.GetComponent<Rigidbody>().isKinematic = false;
			//transform.GetComponent<Rigidbody>().freezePosition = false;
		}
	}
	
	void OnTriggerEnter(Collider collider){
		string s = collider.gameObject.name;
		Debug.Log(s);
		if(s == "FireI"){
			inrange=true;
			Inst.text = "灭火器的使用\n3.按下把手开始灭火";
		}
	}
	
	void OnTriggerExit(Collider collider){
		string s = collider.gameObject.name;
		Debug.Log(s);
		if(s == "FireI"){
			inrange=false;
			Inst.text = "灭火器的使用\n2.提起灭火器 指向火源";
		}
	}
}
