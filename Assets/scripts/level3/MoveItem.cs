using UnityEngine;
using System.Collections;
using Juego;

public class MoveItem : MonoBehaviour {
	private Item controlador;
	public float x=2.3f;
	public float y=1.78f;
	// Use this for initialization
	void Start () {
		Vector2 X = new Vector2 (x, y);
		this.GetComponent<Rigidbody2D>().AddForce(X,ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
