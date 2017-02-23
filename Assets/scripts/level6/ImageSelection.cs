using UnityEngine;
using System.Collections;

public class ImageSelection : MonoBehaviour
{
    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnMouseDown()
    {
        Debug.Log("Emtre");
        Debug.Log(gameObject.name);
        if (gameObject.tag != "Correcto")
        {
            GameObject.FindWithTag("GameController").GetComponent<ControllerGame>().reinforcePhase();
        }
        else {
            GameObject.FindWithTag("GameController").GetComponent<ControllerGame>().addCorrectAnswer();
        }
    }
}