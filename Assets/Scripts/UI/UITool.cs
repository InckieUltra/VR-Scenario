using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool
{
    GameObject activePanel;
	
	public UITool(GameObject panel){
		activePanel = panel;
	}
	
	public T GetOrAddComponent<T>() where T:Component{
		if(activePanel.GetComponent<T>()==null)
			activePanel.AddComponent<T>();
		
		return activePanel.GetComponent<T>();
	}
	
	public GameObject FindChildGameObject(string name){
		Transform[] trans = activePanel.GetComponentsInChildren<Transform>();
		
		foreach(Transform item in trans){
			if(item.name==name){
				return item.gameObject;
			}
		}
		
		Debug.LogWarning($"{activePanel.name}里找不到{name}");
		return null;
	}
	
	public T GetOrAddComponentInChildren<T>(string name) where T:Component{
		GameObject child = FindChildGameObject(name);
		if(child){
			if(child.GetComponent<T>()==null)
				child.AddComponent<T>();
			
			return child.GetComponent<T>();
		}
		
		return null;
	}
}
