using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FALSEP : BasePanel
{
    static readonly string path = "Prefabs/Panel/FALSEPanel";
	
	public FALSEP():base(new UIType(path)){}
	
	public override void OnEnter(){
		
	}
}