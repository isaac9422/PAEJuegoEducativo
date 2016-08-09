using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//GameController for level 5
public class Gamecontroler : MonoBehaviour
{
	public Button[] items = new Button[3];
	public Button[] btnItemes = new Button[6];
	public Text[] itemes = new Text[6];
	public Sprite[] incorrectImage = new Sprite[2];
	public Sprite correctImage;
	public Image[] progress = new Image[3];
	public bool win=false;
	private int correctAnswer;
	private Text textoCategoria;
	private Image imagePalabra;
	private AudioSource audioSource;
	private Categoria categoriaSelected;
	private List<Elemento> elementos;
	private Elemento elementoCorrecto;
	private List<Elemento> elementosIncorrecto;
	private List<string> correctsAnswer;
	public List<string> incorrectsAnswer;
	private GameObject panelProgressBar;
	private GameObject panelRewardPhase;
	
	// Use this for initialization
	void Start ()
	{
		// Variables definition and access to the elements
		correctAnswer = 0;
		textoCategoria = GameObject.Find("TextCategory").GetComponent<Text>();
		imagePalabra = GameObject.Find("ImagePalabra").GetComponent<Image>();
		audioSource = GameObject.FindWithTag("Sonido").GetComponent<AudioSource>();
		panelProgressBar = GameObject.Find("PanelProgressBar");
		panelRewardPhase = GameObject.Find("PanelRewardPhase");
		panelRewardPhase.gameObject.SetActive(false);
		
		int aleatorio = Util.getIntCategoria();
		if(aleatorio<0){
			categoriaSelected = Util.getRandomCategory();
		}else{
			categoriaSelected = Util.getCategoria();
		}
		textoCategoria.text = categoriaSelected.getNombre();
		elementos = categoriaSelected.getElementos();
		correctsAnswer = new List<string>();
		initaizeGame ();
	}
	
		// Update is called once per frame
	void Update ()	{	}

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
			GameObject.FindWithTag ("GameController").GetComponent<Gamecontroler> ().rewardPhase();
			StartCoroutine(animationExit());
		}else if(correctAnswer == 3){
			win=true;
			correctAnswer = 0;
			SceneManager.LoadScene(3);
		}
		else{				
			progress [correctAnswer++].color = new Color (0, 12, 255, 255);
			GameObject.FindWithTag ("GameController").GetComponent<Gamecontroler> ().initaizeGame ();
		}
	}
	
	IEnumerator animationExit(){
		yield return new WaitForSeconds(1.5f);
		panelProgressBar.gameObject.SetActive(false);
		panelRewardPhase.gameObject.SetActive(true);
	}

	public void backToMenu(){
		SceneManager.LoadScene (0);
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
				correctsAnswer.Add(correctWord);
			}	
		}
		loadAudio(correctWord);
	}
	
	public void rewardCorrect(){
		int aleatorio = Random.Range(0,correctsAnswer.Count);
		elementosIncorrecto = new List<Elemento>();
		string correctWord = correctsAnswer[aleatorio];
		for(int i = 0; i < elementos.Count;i++){
			if(!elementos[i].getNombre().Equals(correctWord)){
					elementosIncorrecto.Add(elementos[i]);
			}else{
				elementoCorrecto = elementos[i];
			}	
		}
		loadAudio(correctWord);
	}
	
	public void loadAudio(string correctWord){
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
		
		imagePalabra.sprite = correctImage;
	}
	
	public void establishCorrectButton(){
		int ran = Random.Range (0, 6);
		incorrectsAnswer = new List<string>();
		for (int i=0; i<6; i++) {
			if (ran == i) {
				itemes [i].tag = "Correcto";
				btnItemes[i].tag = "Correcto";
				itemes [i].text = elementoCorrecto.getNombre();
			} else {
				itemes [i].tag = "Incorrecto";
				btnItemes[i].tag = "Incorrecto";
				bool flag = true;
				while(flag){
					int a = Random.Range(0,elementosIncorrecto.Count);
					if(!incorrectsAnswer.Contains(elementosIncorrecto[a].getNombre())){
						itemes [i].text = elementosIncorrecto[a].getNombre();
						incorrectsAnswer.Add(elementosIncorrecto[a].getNombre());
						flag = false;
					}
				}
			}			
		}	
	}
}