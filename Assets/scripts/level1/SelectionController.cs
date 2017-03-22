using UnityEngine;

public class SelectionController : MonoBehaviour
{ 
	// Use this for initialization
	public void onClickControl ()	{
		if (gameObject.tag != "Correcto") {
			GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().reinforcePhase ();				
		} else {
			GameObject.FindWithTag ("GameController").GetComponent<InitializeGame> ().addCorrectAnswer ();
		}
	}
}