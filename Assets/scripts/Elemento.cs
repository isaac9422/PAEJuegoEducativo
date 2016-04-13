using UnityEngine;
using System;
using System.Collections;

public class Elemento {

	private string nombre;
	private string figura;
	
	public Elemento(){
		
	}
	
	public Elemento(string nombre){
		this.nombre = nombre;
		this.figura = "figura";
	}
	
	public string getNombre(){
		return this.nombre;
	}
	
	public void setNombre(string nombre){
		this.nombre = nombre;
	}
	
	public string getFigura(){
		return this.figura;
	}
	
	public void setFigura(string figura){
		this.figura = figura;
	}
}
