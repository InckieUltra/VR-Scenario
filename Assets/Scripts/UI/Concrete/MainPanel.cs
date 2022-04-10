using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : BasePanel
{
    static readonly string path = "Prefabs/Panel/MainPanel";
	
	public MainPanel():base(new UIType(path)){}
	
	public override void OnEnter(){
		UITool.GetOrAddComponentInChildren<Button>("Scenarios").onClick.AddListener(()=>{
			Debug.Log("Scenarios");
			PanelManager.Push(new ScenePanel());
		});
		UITool.GetOrAddComponentInChildren<Button>("Facility").onClick.AddListener(()=>{
			PanelManager.Push(new FacilityPanel());
		});
		UITool.GetOrAddComponentInChildren<Button>("Knowledge").onClick.AddListener(()=>{
			PanelManager.Push(new KnowledgePanel());
		});
		UITool.GetOrAddComponentInChildren<Button>("ExitMain").onClick.AddListener(()=>{
			Debug.Log("ExitMain");
			SceneManager.LoadScene("StartMenu");
		});
	}
}
