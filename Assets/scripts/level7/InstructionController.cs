using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionController : MonoBehaviour {
	
	public Text textMessage;
	// Use this for initialization
	void Start () {
		textMessage = GameObject.Find("TextMessage").GetComponent<Text>();
		textMessage.text = Util.getMessage();
	}
	
	// Update is called once per frame
	void Update () {	}
	
	public void mostrarMensaje(){
		textMessage.text = Util.getMensaje();
	}
	
	public void showMessage(){
		textMessage.text = Util.getMessage();
	}
			
	public void backToCategory(){
		SceneManager.LoadScene ("level4");
	}
			
	public void loadLevel(){
		SceneManager.LoadScene ("level"+Util.getLevel());
}
}
