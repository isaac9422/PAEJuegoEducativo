using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Game_controller for level 2
public class Game_controller : MonoBehaviour
{
	public int correctAnswer;
	public int correctMatches;
	public string textImage;
	public string textWord;
	public List<string> textCorrect;
	public List<string> textIncorrect;
	
	public Sprite imageLoad;
	public Image[] progress = new Image[3];
	
	public Categoria categoriaSelected;
	public List<Elemento> elementos;
	public List<Elemento> elementosCorrecto;
	public List<Elemento> elementosIncorrecto;
	public List<string> correctsAnswer;
	public Text textoCategoria;
	public GameObject panelProgressBar;
	public GameObject panelRewardPhase;
	
	public SpriteRenderer[] imagenes = new SpriteRenderer[3];
	public TextMesh[] correctaMesh = new TextMesh[3];
	public TextMesh[] palabraMesh = new TextMesh[6];
	public bool matchIncorrect;
	private int wrong = 1;
	
	// Use this for initialization
	void Start ()
	{
		// Definition an initialization of the variables
		matchIncorrect = false;
		correctAnswer = 0;
		correctMatches = 0;
		textoCategoria = GameObject.Find("TextCategory").GetComponent<Text>();
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
		
		initializeGame();
	}

	// Update is called once per frame
	void Update ()	{	}
	
	public void initializeGame(){
		textCorrect = new List<string>();
		textIncorrect = new List<string>();
		elementosCorrecto = new List<Elemento>();
		elementosIncorrecto = new List<Elemento>();
		
		selectCorrect();
		loadImages();
		establishCorrect();
	}
	
	public void rewardPhase(){
		
		PopupManager.setTextPopup("Congratulations!. Now let's review what you have learned and you will win a prize.\n ¡Felicitaciones! Vamos a repasar lo aprendido y ganarás un premio");
		PopupManager.showPopup(true);
		textCorrect = new List<string>();
		textIncorrect = new List<string>();
		elementosCorrecto = new List<Elemento>();
		elementosIncorrecto = new List<Elemento>();
		
		rewardCorrect();
		loadImages();
		establishCorrect();
	}
	
	public void reinforcePhase(){
		matchIncorrect = false;
		
		GameObject[] correctWords = GameObject.FindGameObjectsWithTag ("CorrectoWord");
		List<string> wordsSelected = new List<string>();
		foreach (GameObject correctWord in correctWords) {
				string stringCorrectWord = correctWord.GetComponent<textController>().text;
				wordsSelected.Add(stringCorrectWord);
		}
		
		GameObject[] correctImages = GameObject.FindGameObjectsWithTag ("CorrectoImage");
		List<string> imagesSelected = new List<string>();
		foreach (GameObject correctImage in correctImages) {
				string stringCorrectImage = correctImage.GetComponent<ImageController>().textImage;
				imagesSelected.Add(stringCorrectImage);
		}
		loadImages();
		establishCorrect();
		
		for(int i=0;i<3;i++){
			bool bandera = false;
			string textImage = imagenes[i].GetComponent<ImageController> ().textImage;
			foreach (string stringCorrectImage in imagesSelected) {
				if((string.Compare(textImage,stringCorrectImage,true)) == 0){
					bandera = true;
				}
			}
			if(bandera){
				imagenes[i].GetComponent<ImageController> ().sucess ();
			}else{
				imagenes[i].GetComponent<ImageController> ().clear ();
			}			
		}
		
		for(int i=0;i<6;i++){
			bool bandera = false;
			string textWord = palabraMesh[i].text;
			foreach (string stringCorrectWord in wordsSelected) {
				if((string.Compare(textWord,stringCorrectWord,true)) == 0){
					bandera = true;
				}
			}
			if(bandera){
				palabraMesh[i].GetComponent<textController> ().sucess ();
			}else{
				palabraMesh[i].GetComponent<textController> ().clear ();
			}			
		}
		
	}

	public void checkWordImage ()
	{
		if (GameObject.FindGameObjectWithTag ("SelectedImage") != null) {
			if (GameObject.FindGameObjectWithTag ("SelectedWord") != null) {
				textImage = GameObject.FindGameObjectWithTag ("SelectedImage").GetComponent<ImageController> ().textImage;
				textWord = GameObject.FindGameObjectWithTag ("SelectedWord").GetComponent<textController> ().text;
				if (textImage == textWord) {
					string nombre = elementosCorrecto.Find(x => x.getNombre().Contains(textImage)).getNombreSpa();
					string name = elementosCorrecto.Find(x => x.getNombre().Contains(textImage)).getNombre();
					string s = "You're correct!, "+name+" translate as: "+nombre;
					s += "\nHas acertado, la traducción de "+name+" es: "+nombre;
					PopupManager.setTextPopup(s);
					PopupManager.showPopup(true);
										
					GameObject.FindGameObjectWithTag ("SelectedWord").tag = "CorrectoWord";
					GameObject.FindGameObjectWithTag ("SelectedImage").tag = "CorrectoImage";
					addCorrectAnswer ();
					succes ();
				} else {
					GameObject.FindGameObjectWithTag ("SelectedWord").GetComponent<textController> ().clear ();
					GameObject.FindGameObjectWithTag ("SelectedImage").GetComponent<ImageController> ().clear ();
					if(matchIncorrect){	
						wrong++;
						if(wrong >= 2){
							// PopupManager.setTextPopup("Pon atención, mira las respuestas que aparecen debajo de las figuras en letra verde
							PopupManager.setTextPopup("Pay attention, check the answers under the figures in green letter.\n Pon atención, mira las respuestas que aparecen debajo de las figuras en letra verde");
							PopupManager.showPopup(false);
							wrong = 0;
						}
						StartCoroutine(seeSolution());
					}else{
						matchIncorrect = true;
					}
					}
				}
		}
		

	}

	public void succes ()
	{	
		wrong = 0;
		GameObject[] correctWords = GameObject.FindGameObjectsWithTag ("CorrectoWord");
		foreach (GameObject correctWord in correctWords) {
				correctWord.GetComponent<textController> ().sucess ();
				
		}
		GameObject[] correctImages = GameObject.FindGameObjectsWithTag ("CorrectoImage");
		foreach (GameObject correctImage in correctImages) {
				correctImage.GetComponent<ImageController> ().sucess ();
		}
	}

	public void clear ()
	{		
		GameObject[] correctWords = GameObject.FindGameObjectsWithTag ("CorrectoWord");
		foreach (GameObject correctWord in correctWords) {
				correctWord.GetComponent<textController> ().clear ();
				
		}
		GameObject[] correctImages = GameObject.FindGameObjectsWithTag ("CorrectoImage");
		foreach (GameObject correctImage in correctImages) {
				correctImage.GetComponent<ImageController> ().clear ();
		}
	}

	public void addCorrectAnswer ()
	{
		if(correctMatches == 2){
			correctMatches = 0;
			if (correctAnswer == 2) {
				progress [correctAnswer++].color = new Color (0, 12, 255, 255);
				clear();
				rewardPhase();
				StartCoroutine(animationExit());
			}
			else if (correctAnswer == 3) {
				SceneManager.LoadScene ("level3");
			}
			else {
				progress [correctAnswer++].color = new Color (0, 12, 255, 255);
				clear();
				StartCoroutine(freezaGame());
			}			
		}else{
			correctMatches++;
		}
			
	}
	
	IEnumerator freezaGame(){
		yield return new WaitForSeconds(1f);
		initializeGame();
	}
	
	IEnumerator animationExit(){
		yield return new WaitForSeconds(1.5f);
		panelProgressBar.gameObject.SetActive(false);
		panelRewardPhase.gameObject.SetActive(true);
	}
	
	IEnumerator seeSolution(){
		for(int i=0;i<3;i++){
			correctaMesh[i].gameObject.SetActive(true);
		}
		yield return new WaitForSeconds(5f);
		for(int i=0;i<3;i++){
			correctaMesh[i].gameObject.SetActive(false);
		}
		if(matchIncorrect){
			reinforcePhase();
		}
	}
	
	public void selectCorrect(){
		while(elementosCorrecto.Count < 3){
			int aleatorio = Random.Range(0,elementos.Count);
			if(!elementosCorrecto.Contains(elementos[aleatorio])){
				elementosCorrecto.Add(elementos[aleatorio]);
			}
		}
		elementosIncorrecto = new List<Elemento>();
		for(int i = 0; i < elementos.Count;i++){
			if(!elementosCorrecto.Contains(elementos[i])){
				elementosIncorrecto.Add(elementos[i]);
			}else{
				textCorrect.Add(elementos[i].getNombre());
			}	
		}
		bool flag = true;
		while(flag){
			int ramdon = Random.Range(0,3);
			if(!correctsAnswer.Contains(textCorrect[ramdon])){
				correctsAnswer.Add(textCorrect[ramdon]);
				flag = false;
			}
		}
	}
	
	public void rewardCorrect(){		
		elementosIncorrecto = new List<Elemento>();
		for(int i = 0; i < elementos.Count;i++){
			if(!correctsAnswer.Contains(elementos[i].getNombre())){
				elementosIncorrecto.Add(elementos[i]);
			}else{
				textCorrect.Add(elementos[i].getNombre());
			}	
		}
	}
	
	public void loadImages(){
		float transformX = 2.206178f * 1.28f;
		float transformY = 2.165933f * 1.28f;
		int desfaz = Random.Range(0,3);
		for(int i=0;i<3;i++){
			string ruta = "images/";
			ruta += textCorrect[i].ToLower();
			imageLoad = (Sprite) Resources.Load(ruta,typeof(Sprite));
			imagenes[(desfaz+i)%3].sprite = imageLoad;
			imagenes[(desfaz+i)%3].transform.localScale = new Vector3((transformX / imageLoad.bounds.size.x),(transformY / imageLoad.bounds.size.y),0);
		}
		int avance = 3 - desfaz;
		GameObject.Find("Imagen1").GetComponent<ImageController> ().textImage = textCorrect[(avance+0)%3];
		GameObject.Find("Imagen2").GetComponent<ImageController> ().textImage = textCorrect[(avance+1)%3];
		GameObject.Find("Imagen3").GetComponent<ImageController> ().textImage = textCorrect[(avance+2)%3];
		for(int i=0;i<3;i++){
			correctaMesh[(desfaz+i)%3].text = textCorrect[i];
			correctaMesh[(desfaz+i)%3].gameObject.SetActive(false);
		}
	}
	
	public void establishCorrect(){
		int desfaz = Random.Range(0,6);
		int incorrect = 0;
		int correct = 0;
		int indice;
		textIncorrect.Clear();
		while(correct < 3 && incorrect < 3){
			indice = (desfaz+correct+incorrect)%6;
			int ran = Random.Range (0, 10);
			if(ran>4){
				palabraMesh[indice].text = textCorrect[correct++];
			}else{
				int a = Random.Range(0,elementosIncorrecto.Count);
				if(!textIncorrect.Contains(elementosIncorrecto[a].getNombre())){
					textIncorrect.Add(elementosIncorrecto[a].getNombre());
					palabraMesh[indice].text = elementosIncorrecto[a].getNombre();
					incorrect++;
				}
			}			
		}
		while(correct<3){
			indice = (desfaz+correct+incorrect)%6;
			palabraMesh[indice].text = textCorrect[correct++];
		}
		while(incorrect<3){
			indice = (desfaz+correct+incorrect)%6;
			int a = Random.Range(0,elementosIncorrecto.Count);
			if(!textIncorrect.Contains(elementosIncorrecto[a].getNombre())){
				textIncorrect.Add(elementosIncorrecto[a].getNombre());
				palabraMesh[indice].text = elementosIncorrecto[a].getNombre();
				incorrect++;
			}
		}
	}
	
	public void backToMenu(){
		SceneManager.LoadScene ("level0");
	}
}