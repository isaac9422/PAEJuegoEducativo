using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Game_controller for level 2
public class Game_controller : MonoBehaviour
{
		private int aciertos;
		private int correctAnswer;
		private string textImage;
		private string textWord;
		public Image[] progress = new Image[3];
		public List<Categoria> categorias;
		// Use this for initialization
		void Start ()
		{
				correctAnswer = 0;

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void checkWordImage ()
		{
				if (GameObject.FindGameObjectWithTag ("SelectedImage") != null) {
						if (GameObject.FindGameObjectWithTag ("SelectedWord") != null) {
								textImage = GameObject.FindGameObjectWithTag ("SelectedImage").GetComponent<ImageController> ().textImage;
								textWord = GameObject.FindGameObjectWithTag ("SelectedWord").GetComponent<textController> ().text;
								if (textImage == textWord) {
										GameObject.FindGameObjectWithTag ("SelectedWord").tag = "CorrectoWord";
										GameObject.FindGameObjectWithTag ("SelectedImage").tag = "CorrectoImage";
										addCorrectAnswer ();
										succes ();
								} else {
										GameObject.FindGameObjectWithTag ("SelectedWord").GetComponent<textController> ().clear ();
										GameObject.FindGameObjectWithTag ("SelectedImage").GetComponent<ImageController> ().clear ();
								}
						}
				}
				
	
		}

		public void succes ()
		{
				
				GameObject[] correctWords = GameObject.FindGameObjectsWithTag ("CorrectoWord");
				foreach (GameObject correctWord in correctWords) {
						correctWord.GetComponent<textController> ().sucess ();
						
				}
				GameObject[] correctImages = GameObject.FindGameObjectsWithTag ("CorrectoImage");
				foreach (GameObject correctImage in correctImages) {
						correctImage.GetComponent<ImageController> ().sucess ();
				}
		}

		public void addCorrectAnswer ()
		{

				if (correctAnswer < 3) {
						progress [correctAnswer].color = new Color (0, 12, 255, 255);
						correctAnswer ++;
				}
				if (correctAnswer == 3) {
						//Application.LoadLevel (0);
						SceneManager.LoadScene (0);
				}
				
		}
	public void backToMenu(){
		//Application.LoadLevel (0);
		SceneManager.LoadScene (0);
	}
		



}

