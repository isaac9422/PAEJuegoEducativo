using UnityEngine;
using System;
using System.Collections;

public class Elemento {

	private string nombre;
	
	public Elemento(){
		
	}
	
	public Elemento(string nombre){
		this.nombre = nombre;
	}
	
	public string getNombre(){
		return this.nombre;
	}
	
	public void setNombre(string nombre){
		this.nombre = nombre;
	}
}
