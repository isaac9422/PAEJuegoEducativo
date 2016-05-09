using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CategoriaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
			
	public void backToMenu(){
		SceneManager.LoadScene (0);
	}
			
	public void loadLevel(int i){
		Util.setCategoria(i);
		SceneManager.LoadScene (Util.getLevel());
	}
}
