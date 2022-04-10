using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attach : MonoBehaviour
{
	
	public GameObject subject;
	Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = this.transform.position-subject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = subject.transform.position+initialPos;
		this.transform.rotation = subject.transform.rotation;
    }
}
