using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//GameController for level 0
public class GameController : MonoBehaviour
{
    public Text textoEntrada;
    Text textoNombre;
    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "level0")
        {
            textoNombre = GameObject.Find("TextName").GetComponent<Text>();
            textoNombre.text = Util.getNombre();
        }
    }

    // Update is called once per frame
    void Update() { }

    public void loadlevel(int level)
    {
        if (level == 1 || level == 2 || level == 6)
        {
            Util.setLevel(level);
            if (Util.getEasyMode())
            {
                Util.createElementsEasyMode();
            }
            else {
                Util.createElements();
            }
            SceneManager.LoadScene("level4");
        }
        else if (level == -1)
        {
            Application.Quit();
        }
        else if (level == 8)
        {
            SceneManager.LoadScene("level8");
        }
        else {
            Util.setNombre(textoEntrada.text);
            SceneManager.LoadScene("level0");
        }
    }

    public void Toggle_Changed(bool newValue)
    {
        Util.setEasyMode(newValue);
    }

}