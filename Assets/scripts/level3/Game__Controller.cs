using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 3
public class Game__Controller : MonoBehaviour
{
	private List<String> premios;
	private List<String> premiosSpa;
	private Text textoPremio;
	private Text textoPremioSpa;
		
	// Use this for initialization
	void Start ()
	{
		textoPremio = GameObject.Find("TextReward").GetComponent<Text>();
		textoPremioSpa = GameObject.Find("TextRewardSpa").GetComponent<Text>();
		defineReward();
		int aleatorio = UnityEngine.Random.Range(0,premios.Count);
		textoPremio.text = premios[aleatorio];
		textoPremioSpa.text = premiosSpa[aleatorio];
		Image image = GameObject.Find("Image").GetComponent<Image>();
		string ruta = "images/";
		ruta += textoPremio.text;
		image.sprite = (Sprite) Resources.Load(ruta,typeof(Sprite));
		StartCoroutine(animationExit());
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
		
	public void backToMenu(){
		SceneManager.LoadScene (0);
	}
	
	public void defineReward(){
		premios = new List<String>();
		premiosSpa = new List<String>();
		premios.Add("Ice cream");
		premios.Add("Pie");
		premios.Add("Candy");
		premios.Add("Cookie");
		premios.Add("Cupcake");
		premios.Add("Flower");
		premios.Add("Fruit");
		premios.Add("Medal");
		premiosSpa.Add("Helado");
		premiosSpa.Add("Torta");
		premiosSpa.Add("Dulce");
		premiosSpa.Add("Galleta");
		premiosSpa.Add("Postre");
		premiosSpa.Add("Flor");
		premiosSpa.Add("Fruta");
		premiosSpa.Add("Medalla");
	}
	
	IEnumerator animationExit(){
		int aleatorio = UnityEngine.Random.Range(0,15);
		yield return new WaitForSeconds(10+aleatorio);
		SceneManager.LoadScene(0);
	}
}
