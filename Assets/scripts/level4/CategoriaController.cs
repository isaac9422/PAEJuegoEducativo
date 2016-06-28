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
			
	public void showInstructions(int categoria){
		if(Util.getLevel()>0){
			Util.setIntCategoria(categoria);
			if(Util.getLevel()==1){
				Util.setMessage("Selecciona la imagen que corresponda a la palabra mencionada");
			}else if(Util.getLevel()==2){
				Util.setMessage("Empareja una imagen con la palabra que represente a la imagen seleccionada");
			}else{
				Util.setMessage("Selecciona");
			}
			SceneManager.LoadScene(7);
		}else{
			SceneManager.LoadScene(0);
		}
		
	}
}
