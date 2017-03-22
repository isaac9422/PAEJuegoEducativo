using System.Collections.Generic;

public class Categoria {

	private string nombre;
	private List<Elemento> elementos;
	
	public Categoria(){
		
	}
	
	public Categoria(string nombre){
		this.nombre = nombre;
		this.elementos = new List<Elemento>();
	}
	public string getNombre(){
		return this.nombre;
	}
	
	public void setNombre(string nombre){
		this.nombre = nombre;
	}
	
	public List<Elemento> getElementos(){
		return this.elementos;
	}
	
	public void setElementos(List<Elemento> elementos){
		this.elementos = elementos;
	}
}
