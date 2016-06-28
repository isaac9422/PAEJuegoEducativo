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
	void Update () {
	
	}
			
	public void backToCategory(){
		SceneManager.LoadScene (4);
	}
			
	public void loadLevel(){
		SceneManager.LoadScene (Util.getLevel());
}
}
