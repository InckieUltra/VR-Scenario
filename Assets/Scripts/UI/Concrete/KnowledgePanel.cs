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
		UITool.GetOrAddComponentInChildren<Button>("Q2").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA2");
		});
		UITool.GetOrAddComponentInChildren<Button>("Q3").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA3");
		});
		UITool.GetOrAddComponentInChildren<Button>("Q4").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA4");
		});
		UITool.GetOrAddComponentInChildren<Button>("Q5").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA5");
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			PanelManager.Pop();
		});
	}
}