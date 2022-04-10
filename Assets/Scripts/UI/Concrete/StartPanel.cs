using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : BasePanel
{
    static readonly string path = "Prefabs/Panel/StartPanel";
	
	public StartPanel():base(new UIType(path)){}
	
	public override void OnEnter(){
		UITool.GetOrAddComponentInChildren<Button>("Start").onClick.AddListener(()=>{
			Debug.Log("Start");
			SceneManager.LoadScene("MainMenu");
		});
	}
}
