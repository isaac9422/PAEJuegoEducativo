using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 3
public class Game__Controller : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}
			
		public void backToMenu(){
			SceneManager.LoadScene (0);
		}
}
