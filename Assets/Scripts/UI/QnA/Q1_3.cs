using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Q1_3 : BasePanel
{
    public GameObject go;
	
	static readonly string path = "Prefabs/Panel/Q1.3";
	
	public Q1_3():base(new UIType(path)){}
	
	public override void OnEnter(){
		go=GameObject.Find("EventSystem");
		UITool.GetOrAddComponentInChildren<Button>("A").onClick.AddListener(()=>{
			falseP();
		});
		UITool.GetOrAddComponentInChildren<Button>("B").onClick.AddListener(()=>{
			trueP();
		});
		UITool.GetOrAddComponentInChildren<Button>("C").onClick.AddListener(()=>{
			falseP();
		});
		UITool.GetOrAddComponentInChildren<Button>("D").onClick.AddListener(()=>{
			falseP();
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			SceneManager.LoadScene("QnA");
		});
		Text tex;
		tex = UITool.GetOrAddComponentInChildren<Text>("Cnt");
		Debug.Log(tex.text);
		tex.text="正确:"+go.GetComponent<Cnt>().T+"  错误:"+go.GetComponent<Cnt>().F;
	}
	
	void trueP(){
		go.GetComponent<Cnt>().T++;
		nextP();
	}
	void falseP(){
		go.GetComponent<Cnt>().F++;
		nextP();
	}
	void nextP(){
		PanelManager.Push(new CntP());
	}
}