using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour {
	
	public static Canvas CanvasPopup;
	private static Text textoPopup;

	// Use this for initialization
	void Start () {
		textoPopup = GameObject.Find("TextPopup").GetComponent<Text>();
		CanvasPopup = GameObject.Find("CanvasPopup").GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void resumeGame(){
		CanvasPopup.enabled = false;
	}
	
	public static void setTextPopup(string message){
		textoPopup.text = message;
	}
	
	public static void showPopup(){
		CanvasPopup.enabled = true;
	}
}
