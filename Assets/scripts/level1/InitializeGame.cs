using UnityEngine;
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
	// private bool reinforce;
	private Animator bun;
	private Text textoCategoria;
	private Text textoPalabra;
	private AudioSource audioSource;
	private List<Categoria> categorias;
	private Categoria categoria;
	private Elemento elemento;
	private List<Elemento> elementos;
	private Elemento elementoCorrecto;
	private List<Elemento> elementosIncorrecto;
	private List<string> correctsAnswer;
	
	// Use this for initialization
	void Start ()
	{
		// reinforce = false;
		correctAnswer = 0;
		bun = GameObject.Find("Bun").GetComponent<Animator>();
		bun.gameObject.SetActive(false);
		textoCategoria = GameObject.Find("TextCategory").GetComponent<Text>();
		textoPalabra = GameObject.Find("TextPalabra").GetComponent<Text>();
		audioSource = GameObject.FindWithTag("Sonido").GetComponent<AudioSource>();
		createElements();
		
		int aleatorio = UnityEngine.Random.Range(0,categorias.Count);
		textoCategoria.text = categorias[aleatorio].getNombre();
		elementos = categorias[aleatorio].getElementos();
		correctsAnswer = new List<string>();
		initaizeGame ();
	}
	
		// Update is called once per frame
	void Update ()
	{

	}

	public void initaizeGame ()
	{
		selectCorrect();		
		loadImages();		
		establishCorrectButton();
	}

	public void reinforcePhase ()
	{
		loadImages();
		audioSource.Play();
		establishCorrectButton();
	}
	
	public void rewardPhase(){
		rewardCorrect();
		loadImages();
		establishCorrectButton();
	}

	public void addCorrectAnswer ()
	{
		if (correctAnswer == 2) {
			progress [correctAnswer++].color = new Color (0, 12, 255, 255);
			GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().rewardPhase();
		}else if(correctAnswer == 3){
			win=true;
			correctAnswer = 0;
			bun.gameObject.SetActive(true);
			GameObject.FindGameObjectWithTag("Bun").GetComponent<BunAnimation>().changeFace();
			for (int i=0; i<3; i++) {
					// progress [i].color = new Color (0, 12, 255, 0);
			}	
		}
		else{				
			progress [correctAnswer++].color = new Color (0, 12, 255, 255);
			GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().initaizeGame ();
		}
	}

	public void backToMenu(){
		SceneManager.LoadScene (0);
	}
	
	public void createElements(){

		//Creation for categories
		categorias = new List<Categoria>();
		categoria = new Categoria("Fruits");
		categorias.Add(categoria);
		categoria = new Categoria("Transports");
		categorias.Add(categoria);
		categoria = new Categoria("Clothes");
		categorias.Add(categoria);
		categoria = new Categoria("Domestics");
		categorias.Add(categoria);
		categoria = new Categoria("Wilds");
		categorias.Add(categoria);
		categoria = new Categoria("Sports");
		categorias.Add(categoria);
		categoria = new Categoria("Technologys");
		categorias.Add(categoria);
		categoria = new Categoria("House");
		categorias.Add(categoria);
		categoria = new Categoria("Places");
		categorias.Add(categoria);
		categoria = new Categoria("Colours");
		categorias.Add(categoria);
		categoria = new Categoria("Musical");
		categorias.Add(categoria);
		categoria = new Categoria("Body");
		categorias.Add(categoria);
		
		//Creation elemento for Fruit's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Oranges");
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
		elemento = new Elemento("Avocado");
		elementos.Add(elemento);
		elemento = new Elemento("Lemon");
		elementos.Add(elemento);
		elemento = new Elemento("Banana");
		elementos.Add(elemento);
		elemento = new Elemento("Watermelon");
		elementos.Add(elemento);
		elemento = new Elemento("Coconut");
		elementos.Add(elemento);
		elemento = new Elemento("Cherry");
		elementos.Add(elemento);
		elemento = new Elemento("Mango");
		elementos.Add(elemento);
		elemento = new Elemento("Peach");
		elementos.Add(elemento);
		elemento = new Elemento("Papaya");
		elementos.Add(elemento);
		categorias[0].setElementos(elementos);
		
		//Creation elemento for Transport's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Boat");
		elementos.Add(elemento);
		elemento = new Elemento("Train");
		elementos.Add(elemento);
		elemento = new Elemento("Motorbike");
		elementos.Add(elemento);
		elemento = new Elemento("Car");
		elementos.Add(elemento);
		elemento = new Elemento("Bus");
		elementos.Add(elemento);
		elemento = new Elemento("Airplane");
		elementos.Add(elemento);
		elemento = new Elemento("Helicopter");
		elementos.Add(elemento);
		elemento = new Elemento("Bike");
		elementos.Add(elemento);
		elemento = new Elemento("Taxi");
		elementos.Add(elemento);
		elemento = new Elemento("Truck");
		elementos.Add(elemento);
		elemento = new Elemento("Tractor");
		elementos.Add(elemento);
		elemento = new Elemento("Balloon");
		elementos.Add(elemento);
		elemento = new Elemento("Tricycle");
		elementos.Add(elemento);
		elemento = new Elemento("Skateboard");
		elementos.Add(elemento);
		elemento = new Elemento("Shuttle");
		elementos.Add(elemento);
		categorias[1].setElementos(elementos);
		
		//Creation elemento for Clothe's category
		elementos = new List<Elemento>();
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
		elemento = new Elemento("Jacket");
		elementos.Add(elemento);
		elemento = new Elemento("Tenis");
		elementos.Add(elemento);
		elemento = new Elemento("Skirt");
		elementos.Add(elemento);
		elemento = new Elemento("Overcoat");
		elementos.Add(elemento);
		elemento = new Elemento("Tie");
		elementos.Add(elemento);
		elemento = new Elemento("Gloves");
		elementos.Add(elemento);
		elemento = new Elemento("Glass");
		elementos.Add(elemento);
		elemento = new Elemento("Boots");
		elementos.Add(elemento);
		elemento = new Elemento("Scarf");
		elementos.Add(elemento);
		elemento = new Elemento("Bag");
		elementos.Add(elemento);
		elemento = new Elemento("Watch");
		elementos.Add(elemento);
		elemento = new Elemento("Umbrella");
		elementos.Add(elemento);
		elemento = new Elemento("Belt");
		elementos.Add(elemento);
		categorias[2].setElementos(elementos);
		
		//Creation elemento for Domestic's category
		elementos = new List<Elemento>();
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
		elemento = new Elemento("Pig");
		elementos.Add(elemento);
		elemento = new Elemento("Duck");
		elementos.Add(elemento);
		elemento = new Elemento("Bird");
		elementos.Add(elemento);
		elemento = new Elemento("Butterfly");
		elementos.Add(elemento);
		elemento = new Elemento("Chicken");
		elementos.Add(elemento);
		elemento = new Elemento("Frog");
		elementos.Add(elemento);
		elemento = new Elemento("Snail");
		elementos.Add(elemento);
		elemento = new Elemento("Fish");
		elementos.Add(elemento);
		elemento = new Elemento("Mouse");
		elementos.Add(elemento);
		elemento = new Elemento("Sheep");
		elementos.Add(elemento);
		categorias[3].setElementos(elementos);
		
		//Creation elemento for Wild's category
		elementos = new List<Elemento>();
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
		elemento = new Elemento("Elephant");
		elementos.Add(elemento);
		elemento = new Elemento("Bear");
		elementos.Add(elemento);
		elemento = new Elemento("Giraffe");
		elementos.Add(elemento);
		elemento = new Elemento("Crocodile");
		elementos.Add(elemento);
		elemento = new Elemento("Spider");
		elementos.Add(elemento);
		elemento = new Elemento("Camel");
		elementos.Add(elemento);
		elemento = new Elemento("Bee");
		elementos.Add(elemento);
		elemento = new Elemento("Cow");
		elementos.Add(elemento);
		elemento = new Elemento("Tortoise");
		elementos.Add(elemento);
		elemento = new Elemento("Bat");
		elementos.Add(elemento);
		categorias[4].setElementos(elementos);
		
		//Creation elemento for Sports's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Soccer");
		elementos.Add(elemento);
		elemento = new Elemento("Basketball");
		elementos.Add(elemento);
		elemento = new Elemento("Tennis");
		elementos.Add(elemento);
		elemento = new Elemento("Skiing");
		elementos.Add(elemento);
		elemento = new Elemento("Golf");
		elementos.Add(elemento);
		elemento = new Elemento("Archery");
		elementos.Add(elemento);
		elemento = new Elemento("Baseball");
		elementos.Add(elemento);
		elemento = new Elemento("Windsurf");
		elementos.Add(elemento);
		elemento = new Elemento("Hockey");
		elementos.Add(elemento);
		elemento = new Elemento("Judo");
		elementos.Add(elemento);
		elemento = new Elemento("Hurdles");
		elementos.Add(elemento);
		elemento = new Elemento("Athletics");
		elementos.Add(elemento);
		elemento = new Elemento("Weightlifting");
		elementos.Add(elemento);
		elemento = new Elemento("Fencing");
		elementos.Add(elemento);
		elemento = new Elemento("Gymnastics");
		elementos.Add(elemento);
		categorias[5].setElementos(elementos);
		
		//Creation elemento for Technology's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Television");
		elementos.Add(elemento);
		elemento = new Elemento("Computer");
		elementos.Add(elemento);
		elemento = new Elemento("Tablet");
		elementos.Add(elemento);
		elemento = new Elemento("Cellphone");
		elementos.Add(elemento);
		elemento = new Elemento("Telephone");
		elementos.Add(elemento);
		elemento = new Elemento("Printer");
		elementos.Add(elemento);
		elemento = new Elemento("Headphones");
		elementos.Add(elemento);
		elemento = new Elemento("Videogame");
		elementos.Add(elemento);
		elemento = new Elemento("Camera");
		elementos.Add(elemento);
		elemento = new Elemento("Radio");
		elementos.Add(elemento);
		elemento = new Elemento("Stereo");
		elementos.Add(elemento);
		elemento = new Elemento("Refrigerator");
		elementos.Add(elemento);
		elemento = new Elemento("Toaster");
		elementos.Add(elemento);
		elemento = new Elemento("Kettle");
		elementos.Add(elemento);
		elemento = new Elemento("Washer");
		elementos.Add(elemento);
		elemento = new Elemento("Cooler");
		elementos.Add(elemento);
		elemento = new Elemento("Blender");
		elementos.Add(elemento);
		elemento = new Elemento("Oven");
		elementos.Add(elemento);
		elemento = new Elemento("Keyboard");
		elementos.Add(elemento);
		categorias[6].setElementos(elementos);
		
		//Creation elemento for House's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Bed");
		elementos.Add(elemento);
		elemento = new Elemento("Chair");
		elementos.Add(elemento);
		elemento = new Elemento("Table");
		elementos.Add(elemento);
		elemento = new Elemento("Toilet");
		elementos.Add(elemento);
		elemento = new Elemento("Towel");
		elementos.Add(elemento);
		elemento = new Elemento("Bath");
		elementos.Add(elemento);
		elemento = new Elemento("Settee");
		elementos.Add(elemento);
		elemento = new Elemento("Bookshelf");
		elementos.Add(elemento);
		elemento = new Elemento("Lamp");
		elementos.Add(elemento);
		elemento = new Elemento("Cushion");
		elementos.Add(elemento);
		elemento = new Elemento("Candle");
		elementos.Add(elemento);
		elemento = new Elemento("Windows");
		elementos.Add(elemento);
		elemento = new Elemento("Door");
		elementos.Add(elemento);
		elemento = new Elemento("Stairs");
		elementos.Add(elemento);
		elemento = new Elemento("Toothbrush");
		elementos.Add(elemento);
		elemento = new Elemento("Toothpaste");
		elementos.Add(elemento);
		elemento = new Elemento("Broom");
		elementos.Add(elemento);
		elemento = new Elemento("Book");
		elementos.Add(elemento);
		elemento = new Elemento("Keys");
		elementos.Add(elemento);
		categorias[7].setElementos(elementos);
		
		//Creation elemento for Place's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Park");
		elementos.Add(elemento);
		elemento = new Elemento("Building");
		elementos.Add(elemento);
		elemento = new Elemento("Hospital");
		elementos.Add(elemento);
		elemento = new Elemento("Bus stop");
		elementos.Add(elemento);
		elemento = new Elemento("Airport");
		elementos.Add(elemento);
		elemento = new Elemento("Gas station");
		elementos.Add(elemento);
		elemento = new Elemento("School");
		elementos.Add(elemento);
		elemento = new Elemento("Library");
		elementos.Add(elemento);
		elemento = new Elemento("House");
		elementos.Add(elemento);
		elemento = new Elemento("Shop");
		elementos.Add(elemento);
		elemento = new Elemento("Supermarket");
		elementos.Add(elemento);
		elemento = new Elemento("Garden");
		elementos.Add(elemento);
		elemento = new Elemento("Garage");
		elementos.Add(elemento);
		elemento = new Elemento("Bank");
		elementos.Add(elemento);
		elemento = new Elemento("Castle");
		elementos.Add(elemento);
		elemento = new Elemento("Church");
		elementos.Add(elemento);
		elemento = new Elemento("Drugstore");
		elementos.Add(elemento);
		categorias[8].setElementos(elementos);
		
		//Creation elemento for Colour's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Yellow");
		elementos.Add(elemento);
		elemento = new Elemento("Black");
		elementos.Add(elemento);
		elemento = new Elemento("Blue");
		elementos.Add(elemento);
		elemento = new Elemento("Red");
		elementos.Add(elemento);
		elemento = new Elemento("Purple");
		elementos.Add(elemento);
		elemento = new Elemento("Green");
		elementos.Add(elemento);
		elemento = new Elemento("Gray");
		elementos.Add(elemento);
		elemento = new Elemento("Pink");
		elementos.Add(elemento);
		elemento = new Elemento("Brown");
		elementos.Add(elemento);
		elemento = new Elemento("Violet");
		elementos.Add(elemento);
		elemento = new Elemento("Fuchsia");
		elementos.Add(elemento);
		elemento = new Elemento("White");
		elementos.Add(elemento);
		elemento = new Elemento("Orange");
		elementos.Add(elemento);
		categorias[9].setElementos(elementos);
		
		//Creation elemento for Musical's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Guitar");
		elementos.Add(elemento);
		elemento = new Elemento("Clarinet");
		elementos.Add(elemento);
		elemento = new Elemento("Drum");
		elementos.Add(elemento);
		elemento = new Elemento("Drumstick");
		elementos.Add(elemento);
		elemento = new Elemento("Piano");
		elementos.Add(elemento);
		elemento = new Elemento("Saxophone");
		elementos.Add(elemento);
		elemento = new Elemento("Maracas");
		elementos.Add(elemento);
		elemento = new Elemento("Trombone");
		elementos.Add(elemento);
		elemento = new Elemento("Trumpet");
		elementos.Add(elemento);
		elemento = new Elemento("Xylophone");
		elementos.Add(elemento);
		elemento = new Elemento("Violin");
		elementos.Add(elemento);
		elemento = new Elemento("Accordion");
		elementos.Add(elemento);
		elemento = new Elemento("Cymbals");
		elementos.Add(elemento);
		elemento = new Elemento("Drums");
		elementos.Add(elemento);
		elemento = new Elemento("Harp");
		elementos.Add(elemento);
		elemento = new Elemento("Tambourine");
		elementos.Add(elemento);
		categorias[10].setElementos(elementos);
		
		//Creation elemento for Body's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Eyes");
		elementos.Add(elemento);
		elemento = new Elemento("Nose");
		elementos.Add(elemento);
		elemento = new Elemento("Hand");
		elementos.Add(elemento);
		elemento = new Elemento("Foot");
		elementos.Add(elemento);
		elemento = new Elemento("Ankle");
		elementos.Add(elemento);
		elemento = new Elemento("Knee");
		elementos.Add(elemento);
		elemento = new Elemento("Eyebrow");
		elementos.Add(elemento);
		elemento = new Elemento("Lips");
		elementos.Add(elemento);
		elemento = new Elemento("Ear");
		elementos.Add(elemento);
		elemento = new Elemento("Mouth");
		elementos.Add(elemento);
		elemento = new Elemento("Tooth");
		elementos.Add(elemento);
		elemento = new Elemento("Finger");
		elementos.Add(elemento);
		categorias[11].setElementos(elementos);
	}
	
	public void selectCorrect(){
		int aleatorio = Random.Range(0,elementos.Count);
		elementoCorrecto = elementos[aleatorio];
		elementosIncorrecto = new List<Elemento>();
		string correctWord = elementoCorrecto.getNombre();
		for(int i = 0; i < elementos.Count;i++){
			if(!elementos[i].getNombre().Equals(correctWord)){
					elementosIncorrecto.Add(elementos[i]);
			}else{
				textoPalabra.text = correctWord;
				correctsAnswer.Add(correctWord);
			}	
		}
		string ruta = "sounds/En-us-";
		ruta += correctWord.ToLower();
		AudioClip audioClip = (AudioClip) Resources.Load(ruta,typeof(AudioClip));
		if(audioClip == null){
				Debug.Log("Null");
		}else{
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}
	
	public void rewardCorrect(){
		int aleatorio = Random.Range(0,correctsAnswer.Count);
		elementosIncorrecto = new List<Elemento>();
		string correctWord = correctsAnswer[aleatorio];
		for(int i = 0; i < elementos.Count;i++){
			if(!elementos[i].getNombre().Equals(correctWord)){
					elementosIncorrecto.Add(elementos[i]);
			}else{
				textoPalabra.text = correctWord;
				elementoCorrecto = elementos[i];
			}	
		}
		string ruta = "sounds/En-us-";
		ruta += correctWord.ToLower();
		AudioClip audioClip = (AudioClip) Resources.Load(ruta,typeof(AudioClip));
		if(audioClip == null){
				Debug.Log("Null");
		}else{
			audioSource.clip = audioClip;
			audioSource.Play();
		}
	}
	
	public void loadImages(){
		int a = 0;
		int b = 0;
		while(a==b){
			a = Random.Range(0,elementosIncorrecto.Count);	
			b = Random.Range(0,elementosIncorrecto.Count);	
		}
		string ruta = "images/";
		ruta += elementoCorrecto.getNombre().ToLower();
		correctImage = (Sprite) Resources.Load(ruta,typeof(Sprite));
		ruta = "images/";
		ruta += elementosIncorrecto[a].getNombre().ToLower();
		incorrectImage[0] = (Sprite) Resources.Load(ruta,typeof(Sprite));
		ruta = "images/";
		ruta += elementosIncorrecto[b].getNombre().ToLower();
		incorrectImage[1] = (Sprite) Resources.Load(ruta,typeof(Sprite));
	}
	
	public void establishCorrectButton(){
		int ran = Random.Range (0, 3);
		int incorrect = 0;
		for (int i=0; i<3; i++) {
			if (ran == i) {
				items [i].tag = "Correcto";
				items [i].image.sprite = correctImage;
			} else {
				items [i].tag = "Incorrecto";
				items [i].image.sprite = incorrectImage [incorrect++];
			}			
		}
	}
}
