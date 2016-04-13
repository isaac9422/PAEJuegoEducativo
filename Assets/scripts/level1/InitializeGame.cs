﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//GameController for level 1
public class InitializeGame : MonoBehaviour
{
		public Button[] items = new Button[3];
		public Sprite[] incorrectImage = new Sprite[2];
		public Sprite correctImage;
		public Image[] progress = new Image[3];
		public bool win=false;
		private int correctAnswer;
		private bool reinforce;
		public Animator bun;
		public List<Categoria> categorias;
		public Text textoCategoria;
		public Text textoPalabra;
		Categoria categoria;
		Elemento elemento;
		List<Elemento> elementos;
		Elemento elementoCorrecto;
		List<Elemento> elementosIncorrecto;
		
		// Use this for initialization
		void Start ()
		{
				reinforce = false;
				correctAnswer = 0;
				bun = GameObject.Find("Bun").GetComponent<Animator>();
				bun.gameObject.SetActive(false);
				textoCategoria = GameObject.Find("TextCategory").GetComponent<Text>();
				textoPalabra = GameObject.Find("TextPalabra").GetComponent<Text>();
				createElements();
			int aleatorio = UnityEngine.Random.Range(0,categorias.Count);
			textoCategoria.text = categorias[aleatorio].getNombre();
			elementos = categorias[aleatorio].getElementos();
			initaizeGame ();

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void initaizeGame ()
		{
			int aleatorio = UnityEngine.Random.Range(0,elementos.Count);
			elementoCorrecto = elementos[aleatorio];
			elementosIncorrecto = new List<Elemento>();
			for(int i = 0; i < elementos.Count;i++){
				if(!elementos[i].getNombre().Equals(elementoCorrecto.getNombre())){
						elementosIncorrecto.Add(elementos[i]);
				}else{
					textoPalabra.text = elementoCorrecto.getNombre();
				}	
			}
			// string ruta = "/Assets/sounds/En-us-";
			string ruta = "En-us-";
			ruta += elementoCorrecto.getNombre().ToLower();
			AudioClip audioClip = (AudioClip) Resources.Load("",typeof(AudioClip));

			// AudioClip clip = new AudioClip("A:/Jhunior/Universidad/XI Semestre/PAE - Pacho/PaeJuegoEducativo/Assets/sounds/En-us-dress.ogg");
			AudioSource audio = GameObject.FindWithTag("Sonido").GetComponent<AudioSource>();
			if(audioClip == null){
					Debug.Log("Null");
			}else{
				audio.clip = audioClip;
				audio.Play();
			}
			
			int ran = Random.Range (0, 3);
			int incorrect = 0;
			for (int i=0; i<3; i++) {
				if (ran == i) {
					items [i].tag = "Correcto";
					items [i].image.sprite = correctImage;
				} else {
					items [i].tag = "Incorrecto";
					items [i].image.sprite = incorrectImage [incorrect];
					incorrect++;
				}			
			}
		}

		public void addCorrectAnswer ()
		{
				if (reinforce == false) {				
					progress [correctAnswer].color = new Color (0, 12, 255, 255);
					correctAnswer ++;
					GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().initaizeGame ();
				} else {
					reinforce = false;
				}
				if (correctAnswer == 3) {
						win=true;
						correctAnswer = 0;
						bun.gameObject.SetActive(true);
						GameObject.FindGameObjectWithTag("Bun").GetComponent<BunAnimation>().changeFace();
						for (int i=0; i<3; i++) {
								progress [i].color = new Color (0, 12, 255, 0);
						}
				}
		}

		public void reinforcePhase ()
		{
				reinforce = true;
				GameObject.FindWithTag ("GameController").GetComponent<InitializeGame>().initaizeGame ();
		}

	public void backToMenu(){
		SceneManager.LoadScene (0);
	}
	
	public void createElements(){
			elementos = new List<Elemento>();
			//Creation for categories
			categorias = new List<Categoria>();
			categoria = new Categoria("Fruit");
			categorias.Add(categoria);
			categoria = new Categoria("Transports");
			categorias.Add(categoria);
			categoria = new Categoria("Clothes");
			categorias.Add(categoria);
			categoria = new Categoria("Domestic");
			categorias.Add(categoria);
			categoria = new Categoria("Wild");
			categorias.Add(categoria);
			
			//Creation elemento for Fruit's category
			elemento = new Elemento("Orange");
			elementos.Add(elemento);
			elemento = new Elemento("Apple");
			elementos.Add(elemento);
			elemento = new Elemento("Pineapple");
			elementos.Add(elemento);
			elemento = new Elemento("Grape");
			elementos.Add(elemento);
			elemento = new Elemento("Pear");
			elementos.Add(elemento);
			elemento = new Elemento("Berry");
			elementos.Add(elemento);
			categorias[0].setElementos(elementos);
			//elementos.Clear();
			elementos = new List<Elemento>();
			
			//Creation elemento for Transport's category
			elemento = new Elemento("Boat");
			elementos.Add(elemento);
			elemento = new Elemento("Train");
			elementos.Add(elemento);
			elemento = new Elemento("Moto");
			elementos.Add(elemento);
			elemento = new Elemento("Car");
			elementos.Add(elemento);
			elemento = new Elemento("Bus");
			elementos.Add(elemento);
			elemento = new Elemento("Airplane");
			elementos.Add(elemento);
			elemento = new Elemento("Helicopter");
			elementos.Add(elemento);
			categorias[1].setElementos(elementos);
			elementos = new List<Elemento>();
			
			//Creation elemento for Clothe's category
			elemento = new Elemento("Dress");
			elementos.Add(elemento);
			elemento = new Elemento("Shoe");
			elementos.Add(elemento);
			elemento = new Elemento("Pant");
			elementos.Add(elemento);
			elemento = new Elemento("T-Shirt");
			elementos.Add(elemento);
			elemento = new Elemento("Hat");
			elementos.Add(elemento);
			elemento = new Elemento("Sock");
			elementos.Add(elemento);
			categorias[2].setElementos(elementos);
			elementos = new List<Elemento>();
			
			//Creation elemento for Domestic's category
			elemento = new Elemento("Cat");
			elementos.Add(elemento);
			elemento = new Elemento("Horse");
			elementos.Add(elemento);
			elemento = new Elemento("Dog");
			elementos.Add(elemento);
			elemento = new Elemento("Penguin");
			elementos.Add(elemento);
			elemento = new Elemento("Rabbit");
			elementos.Add(elemento);
			elemento = new Elemento("Monkey");
			elementos.Add(elemento);
			categorias[3].setElementos(elementos);
			elementos = new List<Elemento>();
			
			//Creation elemento for Foreign's category
			elemento = new Elemento("Snake");
			elementos.Add(elemento);
			elemento = new Elemento("Shark");
			elementos.Add(elemento);
			elemento = new Elemento("Lion");
			elementos.Add(elemento);
			elemento = new Elemento("Tiger");
			elementos.Add(elemento);
			elemento = new Elemento("Fox");
			elementos.Add(elemento);
			elemento = new Elemento("Bear");
			elementos.Add(elemento);
			categorias[4].setElementos(elementos);
			elementos = new List<Elemento>();
	}

}