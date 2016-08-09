using UnityEngine;
using System.Collections;

public class colorSwitcher : MonoBehaviour {

	public Transform  prefab1;
	public Transform  prefab2;
	public Transform  prefab3;
	
		// Use this for initialization
	void Start () {	}
	
		// Update is called once per frame
	void Update () {	}
	
	public void activateGravity(){
		prefab1.gameObject.SetActive(true);
		Instantiate(prefab1, prefab1.transform.position, prefab1.transform.rotation);
		prefab1.gameObject.SetActive(false);
	
		prefab2.gameObject.SetActive(true);
		Instantiate(prefab2, prefab2.transform.position, prefab2.transform.rotation);
		prefab2.gameObject.SetActive(false);
	
		prefab3.gameObject.SetActive(true);
		Instantiate(prefab3, prefab3.transform.position, prefab3.transform.rotation);
		prefab3.gameObject.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D collision){
		// Debug.Log("Trigger2D");
		GetComponent<Renderer>().material.color = Color.red;
		if(collision.name.Contains("Imagen1")){
			prefab1.gameObject.SetActive(true);
			Instantiate(prefab1, prefab1.transform.position, prefab1.transform.rotation);
			prefab1.gameObject.SetActive(false);
		}
		if(collision.name.Contains("Imagen2")){
			prefab2.gameObject.SetActive(true);
			Instantiate(prefab2, prefab2.transform.position, prefab2.transform.rotation);
			prefab2.gameObject.SetActive(false);
		}
		if(collision.name.Contains("Imagen3")){
			prefab3.gameObject.SetActive(true);
			Instantiate(prefab3, prefab3.transform.position, prefab3.transform.rotation);
			prefab3.gameObject.SetActive(false);
		}
		Destroy(collision.gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		// Debug.Log("Collision2D");
		GetComponent<Renderer>().material.color = Color.red;
		// Debug.Log(collision.gameObject.name);
		Destroy(collision.gameObject);
	}
}
