using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PanelManager panelManager = new PanelManager();
		
		panelManager.Push(new MainPanel());
    }
}
