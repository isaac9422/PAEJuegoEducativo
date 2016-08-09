using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 0
public class GameController : MonoBehaviour
{
	public Text textoEntrada;
	Text textoNombre;
	// Use this for initialization
	void Start ()	{
		if(SceneManager.GetActiveScene().name == "level0"){
			textoNombre = GameObject.Find("TextName").GetComponent<Text>();
			if(Util.getNombre() == ""){
				textoNombre.text = "Player";
			}else{
				textoNombre.text = Util.getNombre();
			}
		}
	}

	// Update is called once per frame
	void Update (){	}

	public void loadlevel (int level)	{
		if (level > 0) {
			Util.setLevel(level);
			Util.createElements();
			SceneManager.LoadScene ("level4");
		} else if (level == -1) {
			Application.Quit();
		}else{
			Util.setNombre(textoEntrada.text);
			SceneManager.LoadScene ("level0");
		}
	}

}