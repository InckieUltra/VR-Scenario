using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refresh : MonoBehaviour
{
	Vector3 initialPos;
	public GameObject subject;
	public double interval = 2.5;
	public double time_ofs;
	double lastTime;
    // Start is called before the first frame update
    void Start()
    {
		initialPos = this.transform.position - subject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if(Time.time - lastTime >= interval){
			this.transform.position = subject.transform.position + initialPos;
			lastTime = Time.time+time_ofs;
		}
    }
}
