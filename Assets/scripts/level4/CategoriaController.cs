using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CategoriaController : MonoBehaviour {

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () { }
			
	public void backToMenu(){
		SceneManager.LoadScene ("level0");
	}
			
	public void showInstructions(int categoria){
		if(Util.getLevel()>0){
			Util.setIntCategoria(categoria);
			if(Util.getLevel()==1){
				Util.setMessage("Select the image that matches to spoken word and that appears in the top box");
				Util.setMensaje("Selecciona la imagen que corresponda a la palabra pronunciada que aparece en el cuadro superior");
			}else if(Util.getLevel()==2){
				Util.setMessage("Touch an image and then touch the word that matches with the selected image");
				Util.setMensaje("Toca una imagen y luego toca la palabra que corresponda a la imagen seleccionada");
			}else{
				Util.setMessage("Look at the images that drop and touch the image that corresponds to spoken word and that appears in the green box");
				Util.setMensaje("Mira las imágenes que caen  y toca la imagen que corresponda a la palabra pronunciada y que aparece en el cuadro verde");
			}
			SceneManager.LoadScene("level7");
		}else{
			backToMenu();
		}
		
	}
}
