using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BunAnimation : MonoBehaviour {
	public Animator bunAnimation;
	// Use this for initialization
	void Start () {
		bunAnimation = GameObject.FindGameObjectWithTag ("Bun").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeFace(){
		StartCoroutine(chageFaceMethod());
	}

	IEnumerator chageFaceMethod() {
		//bunAnimation.gameObject.SetActive(true);
		bunAnimation.GetComponent<Animator>().SetBool ("Win", true);
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(0);
	}
}
