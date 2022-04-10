using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CntP : BasePanel
{
    public GameObject go;
	
	static readonly string path = "Prefabs/Panel/CntPanel";
	
	public CntP():base(new UIType(path)){}
	
	public override void OnEnter(){
		go=GameObject.Find("EventSystem");
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			SceneManager.LoadScene("MainMenu");
		});
		Text tex;
		tex = UITool.GetOrAddComponentInChildren<Text>("Text");
		Debug.Log(tex.text);
		tex.text="正确:"+go.GetComponent<Cnt>().T+"  错误:"+go.GetComponent<Cnt>().F;
	}
}