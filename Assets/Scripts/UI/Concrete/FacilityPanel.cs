using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FacilityPanel : BasePanel
{
    static readonly string path = "Prefabs/Panel/FacilityPanel";
	
	public FacilityPanel():base(new UIType(path)){}
	
	public override void OnEnter(){
		UITool.GetOrAddComponentInChildren<Button>("FE").onClick.AddListener(()=>{
			SceneManager.LoadScene("FireExtinguisher");
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			PanelManager.Pop();
		});
	}
}