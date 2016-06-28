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

	public void loadlevel (int level)
	{
		if (level > 0) {
			Util.setLevel(level);
			Util.createElements();
			SceneManager.LoadScene (4);
		} else if (level == -1) {
			Application.Quit();
		}
	}

}
