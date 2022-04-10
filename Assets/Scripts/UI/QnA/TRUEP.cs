using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TRUEP : BasePanel
{
    static readonly string path = "Prefabs/Panel/TRUEPanel";
	
	public TRUEP():base(new UIType(path)){}
	
	public override void OnEnter(){
		
	}
}