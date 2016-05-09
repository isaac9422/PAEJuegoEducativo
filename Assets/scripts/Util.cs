using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour {

	// Use this for initialization
	static int category = -1;
	static int level = 0;
	private List<Categoria> categorias;
	private Categoria categoria;
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static int getCategoria(){
		return category;
	}
	
	public static void setCategoria(int categor){
		category = categor;
	}
	
	public static int getLevel(){
		return level;
	}
	
	public static void setLevel(int nivel){
		level = nivel;
	}
}
