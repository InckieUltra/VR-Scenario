using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenePanel : BasePanel
{
    static readonly string path = "Prefabs/Panel/ScenePanel";
	
	public ScenePanel():base(new UIType(path)){}
	
	public override void OnEnter(){
		UITool.GetOrAddComponentInChildren<Button>("Stove").onClick.AddListener(()=>{
			Debug.Log("Stove");
			SceneManager.LoadScene("Stove");
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			PanelManager.Pop();
		});
	}
}