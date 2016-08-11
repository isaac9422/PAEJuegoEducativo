using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//GameController for level 6
public class ControllerGame : MonoBehaviour
{
	public SpriteRenderer[] items = new SpriteRenderer[3];
	public Sprite[] incorrectImage = new Sprite[2];
	public Sprite correctImage;
	public Image[] progress = new Image[3];
	public bool win=false;
	private int correctAnswer;
	private Text textoCategoria;
	private Text textoPalabra;
	private AudioSource audioSource;
	private Categoria categoriaSelected;
	private List<Elemento> elementos;
	private Elemento elementoCorrecto;
	private List<Elemento> elementosIncorrecto;
	private List<string> correctsAnswer;
	private GameObject panelProgressBar;
	private GameObject panelRewardPhase;
	private int wrong = 0;
	private colorSwitcher colorSw;
	
	// Use this for initialization
	void Start (){
	
		colorSw = GameObject.Find("BorderDown").GetComponent<colorSwitcher> ();
		// Variables definition and access to the elements
		correctAnswer = 0;
		textoCategoria = GameObject.Find("TextCategory").GetComponent<Text>();
		textoPalabra = GameObject.Find("TextPalabra").GetComponent<Text>();
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
		colorSw.activateGravity();
	}
	
		// Update is called once per frame
	void Update ()	{

	}

	public void initaizeGame ()
	{
		selectCorrect();		
		loadImages();		
		establishCorrectButton();
	}

	public void reinforcePhase ()
	{
		wrong++;
		if(wrong==3){
			wrong = 0;
			PopupManager.setTextPopup("You are wrong! Watch the figure that does not change.\n¡Te equivocaste! Mira la figura que no cambia");
			PopupManager.showPopup(false);
		}
		loadImages();
		audioSource.Play();
		establishCorrectButton();
	}
	
	public void rewardPhase(){
		PopupManager.setTextPopup("Congratulations!. Now let's review what you have learned and you will win a prize.\n ¡Felicitaciones! Vamos a repasar lo aprendido y ganarás un premio");
		PopupManager.showPopup(true);
		rewardCorrect();
		loadImages();
		establishCorrectButton();
	}

	public void addCorrectAnswer ()
	{
		string s = "You're right!, "+elementoCorrecto.getNombre()+" translates as: "+elementoCorrecto.getNombreSpa();
		s += "\nHas acertado, la traducción de "+elementoCorrecto.getNombre()+" es: "+elementoCorrecto.getNombreSpa();
		PopupManager.setTextPopup(s);
		PopupManager.showPopup(true);
		wrong = 0;
		if (correctAnswer == 2) {
			progress [correctAnswer++].color = new Color (0, 12, 255, 255);
			StartCoroutine(animationExit());
			GameObject.FindWithTag ("GameController").GetComponent<ControllerGame> ().rewardPhase();
		}else if(correctAnswer == 3){
			win=true;
			correctAnswer = 0;
			StartCoroutine(animationReward());
		}
		else{				
			progress [correctAnswer++].color = new Color (0, 12, 255, 255);
			GameObject.FindWithTag ("GameController").GetComponent<ControllerGame> ().initaizeGame ();
		}
	}
	
	IEnumerator animationExit(){
		yield return new WaitForSeconds(1f);
		panelProgressBar.gameObject.SetActive(false);
		panelRewardPhase.gameObject.SetActive(true);
	}
	
	IEnumerator animationReward(){
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene("level3");
	}

	public void backToMenu(){
		SceneManager.LoadScene ("level0");
	}
	
	public void selectCorrect(){
		int aleatorio = Random.Range(0,elementos.Count);
		elementoCorrecto = elementos[aleatorio];
		elementosIncorrecto = new List<Elemento>();
		string correctWord = elementoCorrecto.getNombre();
		textoPalabra.text = correctWord;
		correctsAnswer.Add(correctWord);
		for(int i = 0; i < elementos.Count;i++){
			if(!elementos[i].getNombre().Equals(correctWord)){
					elementosIncorrecto.Add(elementos[i]);
			}
		}
		loadAudio(correctWord);
	}
	
	public void rewardCorrect(){
		int aleatorio = Random.Range(0,correctsAnswer.Count);
		elementosIncorrecto = new List<Elemento>();
		string correctWord = correctsAnswer[aleatorio];
		textoPalabra.text = correctWord;
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
	}
	
	public void establishCorrectButton(){
		float transformX = 2.206178f * 1.2f;
		float transformY = 2.165933f * 1.2f;
		int ran = Random.Range (0, 3);
		int incorrect = 0;
		for (int i=0; i<3; i++) {
			if (ran == i) {
				items [i].tag = "Correcto";
				items [i].sprite = correctImage;
			} else {
				items [i].tag = "Incorrecto";
				items [i].sprite = incorrectImage [incorrect++];
			}
			items[i].transform.localScale = new Vector3((transformX / items[i].sprite.bounds.size.x),(transformY / items[i].sprite.bounds.size.y),0);
		}
	}
}