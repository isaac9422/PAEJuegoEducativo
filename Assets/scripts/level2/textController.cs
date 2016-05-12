using UnityEngine;
using System.Collections;

public class textController : MonoBehaviour
{
		private Game_controller gameController;
		public string text;
		// Use this for initialization
		void Start ()
		{
				gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Game_controller> ();
				text = this.GetComponent<TextMesh>().text;
		}
	
		// Update is called once per frame
		void Update ()
		{
				text = this.GetComponent<TextMesh>().text;
		}

		void OnMouseDown ()
		{
				selectText ();
				gameController.checkWordImage ();
		}

		public void selectText ()
		{
				if (GameObject.FindGameObjectWithTag ("SelectedWord") != null) {
						GameObject.FindGameObjectWithTag ("SelectedWord").GetComponent<textController> ().clear ();
				}
				if (tag != "CorrectoWord") {
						tag = "SelectedWord";
						this.GetComponent<TextMesh> ().color = new Color (0, 0.3f, 1, 1);
				}

		}

		/// <summary>
		/// Clear this instance.
		/// </summary>
		public void clear ()
		{
				tag = "Palabra";
				gameObject.GetComponent<TextMesh> ().color = new Color (0, 0, 0);
		}
		
		/// <summary>
		/// Sucess this instance.
		/// </summary>
		public void sucess ()
		{
				tag = "CorrectoWord";
		gameObject.GetComponent<TextMesh> ().color = new Color (0f, 1, 0f);
				//enabled = false;

		}


}
