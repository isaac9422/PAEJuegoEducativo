using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour {

	// Use this for initialization
	static int category = 0;
	static int level = 0;
	private List<Categoria> categorias;
	private Categoria categoria;
	
	void Start () {
		
		//Creation for categories
		categorias = new List<Categoria>();
		categoria = new Categoria("Fruits");
		categorias.Add(categoria);
		categoria = new Categoria("Transports");
		categorias.Add(categoria);
		categoria = new Categoria("Clothes");
		categorias.Add(categoria);
		categoria = new Categoria("Domestics");
		categorias.Add(categoria);
		categoria = new Categoria("Wilds");
		categorias.Add(categoria);
		categoria = new Categoria("Sports");
		categorias.Add(categoria);
		categoria = new Categoria("Technologys");
		categorias.Add(categoria);
		categoria = new Categoria("House");
		categorias.Add(categoria);
		categoria = new Categoria("Places");
		categorias.Add(categoria);
		categoria = new Categoria("Colours");
		categorias.Add(categoria);
		categoria = new Categoria("Musical");
		categorias.Add(categoria);
		categoria = new Categoria("Body");
		categorias.Add(categoria);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int getCategoria(){
		return category;
	}
	
	public void setCategoria(int categor){
		category = categor;
	}
	
	public int getLevel(){
		return level;
	}
	
	public void setLevel(int nivel){
		level = nivel;
	}
}
