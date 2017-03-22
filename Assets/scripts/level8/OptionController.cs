using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionController : MonoBehaviour {

    public Text placeHolderUsername;
    public Toggle easyMode;
    Text textUsername;

	// Use this for initialization
	void Start () {
        textUsername = GameObject.Find("txtUsername").GetComponent<Text>();
        placeHolderUsername.text = Util.getNombre();
        easyMode.isOn = Util.getEasyMode();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void saveOption()
    {
        Util.setEasyMode(easyMode.isOn);
        Util.setNombre(textUsername.text);
        SceneManager.LoadScene("level0");
    }

    public void cancelOption()
    {
        SceneManager.LoadScene("level0");
    }
}
