using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class HandControl : MonoBehaviour {

 
    public float m_speed = 0.5f;
	// Use this for initialization
 
    void Awake () {
 
 
    }
 
    // Update is called once per fram
	
	void Update (){  
        if(Input.GetKey(KeyCode.UpArrow))//如果按下了↑
        {
            this.transform.Translate(new Vector3(m_speed * Time.deltaTime,0,0));//这个物体会在X轴上位移m_speed * Time.deltaTime
        }
        if (Input.GetKey(KeyCode.DownArrow))//如果按下了↓
        {
            this.transform.Translate(new Vector3(-1 * m_speed * Time.deltaTime, 0, 0));//这个Time.deltaTime是一个很小的值大概等于1/帧数
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(0, 0,-1 * m_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(new Vector3(0, 0,  m_speed * Time.deltaTime));
        }
		if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 1 * m_speed * Time.deltaTime, 0));
        }
		if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(new Vector3(-90, 0, 0) * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.R))
        {
            this.transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.F))
        {
            this.transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime);
        }
		if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 1 * m_speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, -1 * m_speed * Time.deltaTime,  0));
        }
		if(Input.GetKeyUp(KeyCode.Space)){
			int count = 0;
			foreach (Transform child in gameObject.transform)
            {
				count++;
				if(count>3){
					Debug.Log ("Trigger Up");
 
					child.GetComponent<Rigidbody>().isKinematic = false;
 
					child.GetComponent<Rigidbody>().useGravity = true;
					
					Rigidbody thisRigidBody=child.GetComponent<Rigidbody>();
					
					thisRigidBody.constraints = RigidbodyConstraints.None;
 
					child.SetParent(null);
				}
            }
		}
	}
 
    /*void tossObject(Rigidbody rigidbody)
 
    {
 
        rigidbody.velocity = gameObject.velocity;
 
        rigidbody.angularVelocity = gameObject.angularVelocity;
 
    }*/
	private int count =0 ;
	void OnCollisionStay(Collision collision){
		Debug.Log(1);
		count++;
		if (Input.GetKey(KeyCode.Space))
 
        {
 
 
            collision.collider.attachedRigidbody.isKinematic = true;
 
            collision.collider.attachedRigidbody.useGravity = false;
 
			collision.collider.gameObject.transform.SetParent(gameObject.transform);
 
 
        }
 
	}
 
 
}