using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//GameController for level 0
public class GameController : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
			
		}

		public void loadlevel (int i)
		{
			if (i > 0) {
					// Application.LoadLevel (i);
					Debug.Log(SceneManager.sceneCount);
					SceneManager.LoadScene (i);
			} else if (i == -1) {
					Application.Quit();
			}
		}

}
