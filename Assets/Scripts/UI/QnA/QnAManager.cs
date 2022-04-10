using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QnAManager : MonoBehaviour
{
    PanelManager panelManager;
	
	private void Awake(){
		panelManager = new PanelManager();
	}
	
	// Start is called before the first frame update
    void Start()
    {
        panelManager.Push(new Q1_1());
    }
}
