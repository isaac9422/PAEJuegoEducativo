using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour {
	
	public static Canvas CanvasPopup;
	private static Text textoPopup;
	public static Text textoTitle;
	public static List<string> titles = new List<string>();

	// Use this for initialization
	void Start () {
		textoPopup = GameObject.Find("TextPopup").GetComponent<Text>();
		textoTitle = GameObject.Find("TextTitle").GetComponent<Text>();
		CanvasPopup = GameObject.Find("CanvasPopup").GetComponent<Canvas>();
		createTitles();
	}
	
	// Update is called once per frame
	void Update () {	}
	
	public void resumeGame(){
		CanvasPopup.enabled = false;
		Time.timeScale = 1;
	}
	
	public static void setTextPopup(string message){
		textoPopup.text = message;
	}
	
	public static void showPopup(bool showTitle){
		if(showTitle){
			int aleatorio = UnityEngine.Random.Range(0,titles.Count);
			textoTitle.text = titles[aleatorio];
		}else{
			textoTitle.text = "";
		}
		CanvasPopup.enabled = true;
		Time.timeScale = 0;
	}
	
	public static void createTitles(){
		titles.Add("Amazing");
		titles.Add("Astonishing");
		titles.Add("Astounding");
		titles.Add("Awesome");
		titles.Add("Breathtaking");
		titles.Add("Brilliant");
		titles.Add("Extraordinary");
		titles.Add("Fabulous");
		titles.Add("Fantastic");
		titles.Add("Great");
		titles.Add("Impressive");
		titles.Add("Marvelous");
		titles.Add("Outstanding");
		titles.Add("Phenomenal");
		titles.Add("Remarkable");
		titles.Add("Spectacular");
		titles.Add("Splendid");
		titles.Add("Very good");
		titles.Add("Wonderful");
		titles.Add("Two thumbs up");
	}
}
