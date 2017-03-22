public class Elemento {

	private string nombre;
	private string nombreSpa;
	
	public Elemento(){
		
	}
	
	public Elemento(string nombre, string nombreSpa){
		this.nombre = nombre;
		this.nombreSpa = nombreSpa;
	}
	
	public string getNombre(){
		return this.nombre;
	}
	
	public void setNombre(string nombre){
		this.nombre = nombre;
	}
	
	public string getNombreSpa(){
		return this.nombreSpa;
	}
	
	public void setNombreSpa(string nombreSpa){
		this.nombreSpa = nombreSpa;
	}
}
