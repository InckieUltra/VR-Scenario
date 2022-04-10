using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KnowledgePanel : BasePanel
{
    static readonly string path = "Prefabs/Panel/QnAPanel";
	
	public KnowledgePanel():base(new UIType(path)){}
	
	public override void OnEnter(){
		UITool.GetOrAddComponentInChildren<Button>("Q1").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA");
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			PanelManager.Pop();
		});
	}
}