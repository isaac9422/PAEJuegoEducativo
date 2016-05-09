using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 3
public class Game__Controller : MonoBehaviour
{
	private List<String> premios;
	private Text textoPremio;
		
	// Use this for initialization
	void Start ()
	{
		textoPremio = GameObject.Find("TextReward").GetComponent<Text>();
		defineReward();
		int aleatorio = UnityEngine.Random.Range(0,premios.Count);
		textoPremio.text = premios[aleatorio];
		StartCoroutine(animationExit());
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
		
	public void backToMenu(){
		SceneManager.LoadScene (0);
	}
	
	public void defineReward(){
		premios = new List<String>();
		premios.Add("Bombón");
		premios.Add("Chocolatina");
		premios.Add("Menta");
		premios.Add("Sorpresa");
		premios.Add("Abrazo");		
	}
	
	IEnumerator animationExit(){
		yield return new WaitForSeconds(10);
		SceneManager.LoadScene(0);
	}
}
