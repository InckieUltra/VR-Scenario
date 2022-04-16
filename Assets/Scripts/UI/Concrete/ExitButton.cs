using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    static readonly string path = "Prefabs/Panel/Exit";
	
	void Start(){
		GameObject parent = GameObject.Find("Canvas");
		GameObject exitButton = GameObject.Instantiate(Resources.Load<GameObject>(path),parent.transform);
		exitButton.GetComponent<Button>().onClick.AddListener(()=>{
			SceneManager.LoadScene("MainMenu");
		});
	}
}