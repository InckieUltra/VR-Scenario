using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QnAM1 : MonoBehaviour
{
    PanelManager panelManager;
	
	private void Awake(){
		panelManager = new PanelManager();
	}
	
	// Start is called before the first frame update
    void Start()
    {
        panelManager.Push(new Q1());
    }
}
