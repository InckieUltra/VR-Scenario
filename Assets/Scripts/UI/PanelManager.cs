using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager
{
    private Stack<BasePanel> stackPanel;
	
	private UIManager uiManager;
	private BasePanel panel;
	
	public PanelManager(){
		stackPanel = new Stack<BasePanel>();
		uiManager = new UIManager();
	}
	
	public void Push(BasePanel nextPanel){
		if(stackPanel.Count>0){
			panel = stackPanel.Peek();
			panel.OnPause();
		}
		stackPanel.Push(nextPanel);
		GameObject panelGo = uiManager.GetSingleUI(nextPanel.UIType);
		nextPanel.Initialize(new UITool(panelGo));
		nextPanel.Initialize(this);
		nextPanel.Initialize(uiManager);
		nextPanel.OnEnter();
	}
	
	public void Pop(){
		if(stackPanel.Count>0){
			stackPanel.Peek().OnExit();
			stackPanel.Pop();
		}
		if(stackPanel.Count>0)
			stackPanel.Peek().OnResume();
	}
}
