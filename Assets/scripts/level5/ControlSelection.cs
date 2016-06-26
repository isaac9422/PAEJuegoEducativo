using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlSelection : MonoBehaviour
{ 
		// Use this for initialization
		public void onClickControl ()
		{
			if (gameObject.tag != "Correcto") {
				GameObject.FindWithTag ("GameController").GetComponent<Gamecontroler> ().reinforcePhase ();							
			} else {
				GameObject.FindWithTag ("GameController").GetComponent<Gamecontroler> ().addCorrectAnswer ();
			}
		}
}