using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Util : MonoBehaviour {

	// Use this for initialization
	static int category = -1;
	static int level = 0;
	private static List<Categoria> categorias;
	private static Categoria categoria;
	private static Elemento elemento;
	private static List<Elemento> elementos;
	
	void Start () {	}
	
	// Update is called once per frame
	void Update () {	}
	
	public static int getIntCategoria(){
		return category;
	}
	
	public static void setIntCategoria(int categor){
		category = categor;
		setCategoria(categorias[categor]);
	}
	
	public static Categoria getCategoria(){
		return categoria;
	}
	
	public static void setCategoria(Categoria categor){
		categoria = categor;
	}
	
	public static int getLevel(){
		return level;
	}
	
	public static void setLevel(int nivel){
		level = nivel;
	}
	
	public static Categoria getRandomCategory(){
		if(categorias==null){
			createElements();
		}
		int aleatorio = UnityEngine.Random.Range(0,categorias.Count);
		return categorias[aleatorio];
	}
	
	public static void createElements(){

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
		
		//Creation elemento for Fruit's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Oranges","Naranja");
		elementos.Add(elemento);
		elemento = new Elemento("Apple","Manzana");
		elementos.Add(elemento);
		elemento = new Elemento("Pineapple","Piña");
		elementos.Add(elemento);
		elemento = new Elemento("Grape","Uva");
		elementos.Add(elemento);
		elemento = new Elemento("Pear","Pera");
		elementos.Add(elemento);
		elemento = new Elemento("Berry","Fresa");
		elementos.Add(elemento);
		elemento = new Elemento("Avocado","Aguacate");
		elementos.Add(elemento);
		elemento = new Elemento("Lemon","Limón");
		elementos.Add(elemento);
		elemento = new Elemento("Banana","Banano");
		elementos.Add(elemento);
		elemento = new Elemento("Watermelon","Sandia");
		elementos.Add(elemento);
		elemento = new Elemento("Coconut","Coco");
		elementos.Add(elemento);
		elemento = new Elemento("Cherry","Cereza");
		elementos.Add(elemento);
		elemento = new Elemento("Mango","Mango");
		elementos.Add(elemento);
		elemento = new Elemento("Peach","Durazno");
		elementos.Add(elemento);
		elemento = new Elemento("Papaya","Papaya");
		elementos.Add(elemento);
		categorias[0].setElementos(elementos);
		
		//Creation elemento for Transport's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Boat","Bote");
		elementos.Add(elemento);
		elemento = new Elemento("Train","Tren");
		elementos.Add(elemento);
		elemento = new Elemento("Motorbike","Motocicleta");
		elementos.Add(elemento);
		elemento = new Elemento("Car","Carro");
		elementos.Add(elemento);
		elemento = new Elemento("Bus","Bus");
		elementos.Add(elemento);
		elemento = new Elemento("Airplane","Avión");
		elementos.Add(elemento);
		elemento = new Elemento("Helicopter","Helicóptero");
		elementos.Add(elemento);
		elemento = new Elemento("Bike","Bicicleta");
		elementos.Add(elemento);
		elemento = new Elemento("Taxi","Taxi");
		elementos.Add(elemento);
		elemento = new Elemento("Truck","Camión");
		elementos.Add(elemento);
		elemento = new Elemento("Tractor","Tractor");
		elementos.Add(elemento);
		elemento = new Elemento("Balloon","Globo");
		elementos.Add(elemento);
		elemento = new Elemento("Tricycle","Triciclo");
		elementos.Add(elemento);
		elemento = new Elemento("Skateboard","Patineta");
		elementos.Add(elemento);
		elemento = new Elemento("Shuttle","Transbordador");
		elementos.Add(elemento);
		categorias[1].setElementos(elementos);
		
		//Creation elemento for Clothe's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Dress","Vestido");
		elementos.Add(elemento);
		elemento = new Elemento("Shoe","Zapato");
		elementos.Add(elemento);
		elemento = new Elemento("Pant","Pantalón");
		elementos.Add(elemento);
		elemento = new Elemento("T-Shirt","Suéter");
		elementos.Add(elemento);
		elemento = new Elemento("Hat","Sombrero");
		elementos.Add(elemento);
		elemento = new Elemento("Sock","Medias");
		elementos.Add(elemento);
		elemento = new Elemento("Jacket","Buso");
		elementos.Add(elemento);
		elemento = new Elemento("Tenis","Tenis");
		elementos.Add(elemento);
		elemento = new Elemento("Skirt","Falda");
		elementos.Add(elemento);
		elemento = new Elemento("Overcoat","Chaqueta");
		elementos.Add(elemento);
		elemento = new Elemento("Tie","Corbata");
		elementos.Add(elemento);
		elemento = new Elemento("Gloves","Guantes");
		elementos.Add(elemento);
		elemento = new Elemento("Glass","Guantes");
		elementos.Add(elemento);
		elemento = new Elemento("Boots","Botas");
		elementos.Add(elemento);
		elemento = new Elemento("Scarf","Bufanda");
		elementos.Add(elemento);
		elemento = new Elemento("Bag","Bolso");
		elementos.Add(elemento);
		elemento = new Elemento("Watch","Reloj");
		elementos.Add(elemento);
		elemento = new Elemento("Belt","Correa");
		elementos.Add(elemento);
		categorias[2].setElementos(elementos);
		
		//Creation elemento for Domestic's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Cat","Gato");
		elementos.Add(elemento);
		elemento = new Elemento("Horse","Caballo");
		elementos.Add(elemento);
		elemento = new Elemento("Dog","Perro");
		elementos.Add(elemento);
		elemento = new Elemento("Penguin","Pingüino");
		elementos.Add(elemento);
		elemento = new Elemento("Rabbit","Conejo");
		elementos.Add(elemento);
		elemento = new Elemento("Monkey","Mono");
		elementos.Add(elemento);
		elemento = new Elemento("Pig","Cerdo");
		elementos.Add(elemento);
		elemento = new Elemento("Duck","Pato");
		elementos.Add(elemento);
		elemento = new Elemento("Bird","Pajaro");
		elementos.Add(elemento);
		elemento = new Elemento("Butterfly","Mariposa");
		elementos.Add(elemento);
		elemento = new Elemento("Chicken","Pollo");
		elementos.Add(elemento);
		elemento = new Elemento("Frog","Sapo");
		elementos.Add(elemento);
		elemento = new Elemento("Snail","Caracol");
		elementos.Add(elemento);
		elemento = new Elemento("Fish","Pescado");
		elementos.Add(elemento);
		elemento = new Elemento("Mouse","Ratón");
		elementos.Add(elemento);
		elemento = new Elemento("Sheep","Oveja");
		elementos.Add(elemento);
		categorias[3].setElementos(elementos);
		
		//Creation elemento for Wild's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Snake","Culebra");
		elementos.Add(elemento);
		elemento = new Elemento("Shark","Tiburón");
		elementos.Add(elemento);
		elemento = new Elemento("Lion","León");
		elementos.Add(elemento);
		elemento = new Elemento("Tiger","Tigre");
		elementos.Add(elemento);
		elemento = new Elemento("Fox","Zorro");
		elementos.Add(elemento);
		elemento = new Elemento("Elephant","Elefante");
		elementos.Add(elemento);
		elemento = new Elemento("Bear","Oso");
		elementos.Add(elemento);
		elemento = new Elemento("Giraffe","Jirafa");
		elementos.Add(elemento);
		elemento = new Elemento("Crocodile","Cocodrilo");
		elementos.Add(elemento);
		elemento = new Elemento("Spider","Araña");
		elementos.Add(elemento);
		elemento = new Elemento("Camel","Camello");
		elementos.Add(elemento);
		elemento = new Elemento("Bee","Abeja");
		elementos.Add(elemento);
		elemento = new Elemento("Cow","Vaca");
		elementos.Add(elemento);
		elemento = new Elemento("Tortoise","Tortuga");
		elementos.Add(elemento);
		elemento = new Elemento("Bat","Murciélago");
		elementos.Add(elemento);
		elemento = new Elemento("Wolf","Lobo");
		elementos.Add(elemento);
		categorias[4].setElementos(elementos);
		
		//Creation elemento for Sports's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Soccer","Fútbol");
		elementos.Add(elemento);
		elemento = new Elemento("Basketball","Baloncesto");
		elementos.Add(elemento);
		elemento = new Elemento("Tennis","Tenis");
		elementos.Add(elemento);
		elemento = new Elemento("Skiing","Esquí");
		elementos.Add(elemento);
		elemento = new Elemento("Golf","Golf");
		elementos.Add(elemento);
		elemento = new Elemento("Archery","Arquería");
		elementos.Add(elemento);
		elemento = new Elemento("Baseball","Béisbol");
		elementos.Add(elemento);
		elemento = new Elemento("Windsurf","Surfear");
		elementos.Add(elemento);
		elemento = new Elemento("Hockey","Hockey");
		elementos.Add(elemento);
		elemento = new Elemento("Judo","Judo");
		elementos.Add(elemento);
		elemento = new Elemento("Hurdles","Salto de vallas");
		elementos.Add(elemento);
		elemento = new Elemento("Athletics","Atletismo");
		elementos.Add(elemento);
		elemento = new Elemento("Weightlifting","Levantamiento de pesas");
		elementos.Add(elemento);
		elemento = new Elemento("Fencing","Esgrima");
		elementos.Add(elemento);
		elemento = new Elemento("Gymnastics","Gimnasía");
		elementos.Add(elemento);
		elemento = new Elemento("Volleyball","Voleibol");
		elementos.Add(elemento);
		elemento = new Elemento("Boxing","Boxeo");
		elementos.Add(elemento);
		elemento = new Elemento("Cycling","Ciclismo");
		elementos.Add(elemento);
		elemento = new Elemento("Rugby","Rugby");
		elementos.Add(elemento);
		elemento = new Elemento("Cricket","Cricket");
		elementos.Add(elemento);
		elemento = new Elemento("Motoring","Automovilismo");
		elementos.Add(elemento);
		elemento = new Elemento("Motorcycling","Motociclismo");
		elementos.Add(elemento);
		categorias[5].setElementos(elementos);
		
		//Creation elemento for Technology's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Television","Televisor");
		elementos.Add(elemento);
		elemento = new Elemento("Computer","Computador");
		elementos.Add(elemento);
		elemento = new Elemento("Tablet","Tablet");
		elementos.Add(elemento);
		elemento = new Elemento("Cellphone","Celular");
		elementos.Add(elemento);
		elemento = new Elemento("Telephone","Teléfono");
		elementos.Add(elemento);
		elemento = new Elemento("Printer","Impresora");
		elementos.Add(elemento);
		elemento = new Elemento("Headphones","Audífonos");
		elementos.Add(elemento);
		elemento = new Elemento("Videogame","Consola");
		elementos.Add(elemento);
		elemento = new Elemento("Camera","Camara");
		elementos.Add(elemento);
		elemento = new Elemento("Radio","Radio");
		elementos.Add(elemento);
		elemento = new Elemento("Stereo","Equipo de sonido");
		elementos.Add(elemento);
		elemento = new Elemento("Refrigerator","Nevera");
		elementos.Add(elemento);
		elemento = new Elemento("Toaster","Tostadora");
		elementos.Add(elemento);
		elemento = new Elemento("Kettle","Tetera");
		elementos.Add(elemento);
		elemento = new Elemento("Washer","Lavadora");
		elementos.Add(elemento);
		elemento = new Elemento("Cooler","Ventilador");
		elementos.Add(elemento);
		elemento = new Elemento("Blender","Licuadora");
		elementos.Add(elemento);
		elemento = new Elemento("Oven","Horno");
		elementos.Add(elemento);
		elemento = new Elemento("Keyboard","Teclado");
		elementos.Add(elemento);
		categorias[6].setElementos(elementos);
		
		//Creation elemento for House's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Bed","Cama");
		elementos.Add(elemento);
		elemento = new Elemento("Chair","Silla");
		elementos.Add(elemento);
		elemento = new Elemento("Table","Mesa");
		elementos.Add(elemento);
		elemento = new Elemento("Toilet","Baño");
		elementos.Add(elemento);
		elemento = new Elemento("Towel","Toalla");
		elementos.Add(elemento);
		elemento = new Elemento("Bath","Ducha");
		elementos.Add(elemento);
		elemento = new Elemento("Settee","Sofa");
		elementos.Add(elemento);
		elemento = new Elemento("Bookshelf","Libreria");
		elementos.Add(elemento);
		elemento = new Elemento("Lamp","Lampara");
		elementos.Add(elemento);
		elemento = new Elemento("Cushion","Cojín");
		elementos.Add(elemento);
		elemento = new Elemento("Candle","Vela");
		elementos.Add(elemento);
		elemento = new Elemento("Windows","Ventana");
		elementos.Add(elemento);
		elemento = new Elemento("Door","Puerta");
		elementos.Add(elemento);
		elemento = new Elemento("Stairs","Escalera");
		elementos.Add(elemento);
		elemento = new Elemento("Toothbrush","Cepillo de dientes");
		elementos.Add(elemento);
		elemento = new Elemento("Toothpaste","Crema de dientes");
		elementos.Add(elemento);
		elemento = new Elemento("Broom","Escoba");
		elementos.Add(elemento);
		elemento = new Elemento("Book","Libro");
		elementos.Add(elemento);
		elemento = new Elemento("Keys","Llave");
		elementos.Add(elemento);
		elemento = new Elemento("Umbrella","Sombrilla");
		elementos.Add(elemento);
		categorias[7].setElementos(elementos);
		
		//Creation elemento for Place's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Park","Parque");
		elementos.Add(elemento);
		elemento = new Elemento("Building","Edificio");
		elementos.Add(elemento);
		elemento = new Elemento("Hospital","Hospital");
		elementos.Add(elemento);
		elemento = new Elemento("Bus stop","Parada de bus");
		elementos.Add(elemento);
		elemento = new Elemento("Airport","Aeropuerto");
		elementos.Add(elemento);
		elemento = new Elemento("Gas station","Gasolinera");
		elementos.Add(elemento);
		elemento = new Elemento("School","Escuela");
		elementos.Add(elemento);
		elemento = new Elemento("Library","Libreria");
		elementos.Add(elemento);
		elemento = new Elemento("House","Casa");
		elementos.Add(elemento);
		elemento = new Elemento("Shop","Tienda");
		elementos.Add(elemento);
		elemento = new Elemento("Supermarket","Supermercado");
		elementos.Add(elemento);
		elemento = new Elemento("Garden","Jardín");
		elementos.Add(elemento);
		elemento = new Elemento("Garage","Garaje");
		elementos.Add(elemento);
		elemento = new Elemento("Bank","Banco");
		elementos.Add(elemento);
		elemento = new Elemento("Castle","Castillo");
		elementos.Add(elemento);
		elemento = new Elemento("Church","Iglesia");
		elementos.Add(elemento);
		elemento = new Elemento("Drugstore","Droguería");
		elementos.Add(elemento);
		categorias[8].setElementos(elementos);
		
		//Creation elemento for Colour's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Yellow","Amarillo");
		elementos.Add(elemento);
		elemento = new Elemento("Black","Negro");
		elementos.Add(elemento);
		elemento = new Elemento("Blue","Azul");
		elementos.Add(elemento);
		elemento = new Elemento("Red","Rojo");
		elementos.Add(elemento);
		elemento = new Elemento("Purple","Púrpura");
		elementos.Add(elemento);
		elemento = new Elemento("Green","Verde");
		elementos.Add(elemento);
		elemento = new Elemento("Gray","Gris");
		elementos.Add(elemento);
		elemento = new Elemento("Pink","Rosado");
		elementos.Add(elemento);
		elemento = new Elemento("Brown","Café");
		elementos.Add(elemento);
		elemento = new Elemento("Violet","Violeta");
		elementos.Add(elemento);
		elemento = new Elemento("Fuchsia","Fúcsia");
		elementos.Add(elemento);
		elemento = new Elemento("White","Blanco");
		elementos.Add(elemento);
		elemento = new Elemento("Orange","Naranja");
		elementos.Add(elemento);
		categorias[9].setElementos(elementos);
		
		//Creation elemento for Musical's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Guitar","Guitarra");
		elementos.Add(elemento);
		elemento = new Elemento("Clarinet","Clarinete");
		elementos.Add(elemento);
		elemento = new Elemento("Drum","Tambor");
		elementos.Add(elemento);
		elemento = new Elemento("Drumstick","Baqueta");
		elementos.Add(elemento);
		elemento = new Elemento("Piano","Piano");
		elementos.Add(elemento);
		elemento = new Elemento("Saxophone","Saxofón");
		elementos.Add(elemento);
		elemento = new Elemento("Maracas","Maracas");
		elementos.Add(elemento);
		elemento = new Elemento("Trombone","Trombón");
		elementos.Add(elemento);
		elemento = new Elemento("Trumpet","Trompeta");
		elementos.Add(elemento);
		elemento = new Elemento("Xylophone","Xilófono");
		elementos.Add(elemento);
		elemento = new Elemento("Violin","Violín");
		elementos.Add(elemento);
		elemento = new Elemento("Accordion","Acordeón");
		elementos.Add(elemento);
		elemento = new Elemento("Cymbals","Platillos");
		elementos.Add(elemento);
		elemento = new Elemento("Drums","Batería");
		elementos.Add(elemento);
		elemento = new Elemento("Harp","Arpa");
		elementos.Add(elemento);
		elemento = new Elemento("Tambourine","Pandereta");
		elementos.Add(elemento);
		categorias[10].setElementos(elementos);
		
		//Creation elemento for Body's category
		elementos = new List<Elemento>();
		elemento = new Elemento("Eyes","Ojos");
		elementos.Add(elemento);
		elemento = new Elemento("Nose","Nariz");
		elementos.Add(elemento);
		elemento = new Elemento("Hand","Mano");
		elementos.Add(elemento);
		elemento = new Elemento("Foot","Pie");
		elementos.Add(elemento);
		elemento = new Elemento("Ankle","Tobillo");
		elementos.Add(elemento);
		elemento = new Elemento("Knee","Rodilla");
		elementos.Add(elemento);
		elemento = new Elemento("Eyebrow","Ceja");
		elementos.Add(elemento);
		elemento = new Elemento("Lips","Labios");
		elementos.Add(elemento);
		elemento = new Elemento("Ear","Oreja");
		elementos.Add(elemento);
		elemento = new Elemento("Mouth","Boca");
		elementos.Add(elemento);
		elemento = new Elemento("Tooth","Diente");
		elementos.Add(elemento);
		elemento = new Elemento("Finger","Dedo");
		elementos.Add(elemento);
		categorias[11].setElementos(elementos);
	}
}