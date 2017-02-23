using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 3
public class PremioController : MonoBehaviour
{
	private List<String> premios;
	private List<String> premiosSpa;
	public Text textoPremio;
	public Text textoPremioSpa;
	public Text textoMensajeGanaste;
	public Button[] button = new Button[2];
	public Image image;
	int a = 0;
	int b = 0;
	public GameObject panelSelect;
	public GameObject panelReward;
		
	// Use this for initialization
	void Start ()	{
		// textoPremio = GameObject.Find("TextReward").GetComponent<Text>();
		// textoPremioSpa = GameObject.Find("TextRewardSpa").GetComponent<Text>();
		// textoMensajeGanaste = GameObject.Find("Text").GetComponent<Text>();
		textoMensajeGanaste.text = Util.getNombre()+" you win!!!\n¡"+Util.getNombre()+" ganaste!";
		// Image image = GameObject.Find("Image").GetComponent<Image>();
		defineReward();
		
		// panelSelect.gameObject.SetActive(false);
		// int aleatorio = UnityEngine.Random.Range(0,premios.Count);
		while(a==b){
			a = UnityEngine.Random.Range(0,premios.Count);	
			b = UnityEngine.Random.Range(0,premios.Count);	
		}
		
		string ruta = "images/";
		ruta += premios[a];
		button [0].image.sprite = (Sprite) Resources.Load(ruta,typeof(Sprite));
		ruta = "images/";
		ruta += premios[b];
		button [1].image.sprite = (Sprite) Resources.Load(ruta,typeof(Sprite));
		// StartCoroutine(animationExit());
	}

	// Update is called once per frame
	void Update () {	}
		
	public void backToMenu(){
		SceneManager.LoadScene ("level0");
	}
	
	public void defineReward(){
		premios = new List<String>();
		premiosSpa = new List<String>();
		// premios.Add("Ice cream");
		premios.Add("Pie");
		premios.Add("Candy");
		premios.Add("Cookie");
		premios.Add("Cupcake");
		premios.Add("Juice");
		premios.Add("Fruit");
		// premios.Add("Medal");
		premios.Add("Ball");
		premios.Add("Chocolate bar");
		premios.Add("Toy");
		// premiosSpa.Add("Helado");
		premiosSpa.Add("Torta");
		premiosSpa.Add("Dulce");
		premiosSpa.Add("Galleta");
		premiosSpa.Add("Postre");
		premiosSpa.Add("Jugo");
		premiosSpa.Add("Fruta");
		// premiosSpa.Add("Medalla");
		premiosSpa.Add("Pelota");
		premiosSpa.Add("Chocolatina");
		premiosSpa.Add("Juguete");
	}
	
	IEnumerator animationExit(){
		int aleatorio = UnityEngine.Random.Range(0,15);
		int aleatorioBase = UnityEngine.Random.Range(10,20);
		yield return new WaitForSeconds(aleatorioBase+aleatorio);
		backToMenu();
	}
	
	public void onClickControl (string opcion)	{
		Debug.Log("Aqui");
		Debug.Log(this.gameObject.tag );
		Debug.Log(gameObject.tag);
		if (opcion == "opcion1") {
			// GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().reinforcePhase();					
			textoPremio.text = premios[a];
			textoPremioSpa.text = premiosSpa[a];
			image.sprite = button[0].image.sprite;
		} else {
			// GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().addCorrectAnswer ();				
			textoPremio.text = premios[b];
			textoPremioSpa.text = premiosSpa[b];
			image.sprite = button[1].image.sprite;
		}
		panelSelect.gameObject.SetActive(false);
		panelReward.gameObject.SetActive(true);
		StartCoroutine(animationExit());
	}
}