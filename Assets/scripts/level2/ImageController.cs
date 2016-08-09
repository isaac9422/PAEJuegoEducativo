using UnityEngine;
using System.Collections;

public class ImageController : MonoBehaviour
{
		public string textImage;
		public TextMesh textInGame;
		private Game_controller gameController;

		// Use this for initialization
		void Start ()
		{
			gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Game_controller> ();
		}
	
		// Update is called once per frame


		void OnMouseDown ()
		{
			selectImage ();
			gameController.checkWordImage ();		
		}
	
		void selectImage ()
		{
				if (GameObject.FindGameObjectWithTag ("SelectedImage") != null) {
						GameObject.FindGameObjectWithTag ("SelectedImage").GetComponent<ImageController> ().clear ();
				}
				if (tag != "CorrectoImage") {
						tag = "SelectedImage";
						gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.1f, 0.1f, 0.1f);
				}
				
		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void clear ()
		{
				tag = "Indefinido";
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		}

		/// <summary>
		/// Sucess this instance.
		/// </summary>
		public void sucess ()
		{
				tag = "CorrectoImage";
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.5f, 1, 0.7f);
		
		}
		


}
