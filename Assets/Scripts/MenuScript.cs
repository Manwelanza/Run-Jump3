using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas optionMenu;
    public Button startText;
    public Button exitText;
    public Button optionText;
    public Button imageStart;
    public Button imageExit;

    // Use this for initialization
    void Start ()
    {
        optionMenu = optionMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        optionText = optionText.GetComponent<Button>();
        imageStart = imageStart.GetComponent<Button>();
        imageExit = imageExit.GetComponent<Button>();
        optionMenu.enabled = false;
        quitMenu.enabled = false;
    }


    // Método que muestra el menu de opciones y desactiva los botones del menu principal
    public void OptionPress ()
    {
        optionMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        optionText.enabled = false;
        imageStart.enabled = false;
        imageExit.enabled = false;
    }

    // Método que desactiva el menu de opciones y reactiva los botones del menu principal
    public void OptionDisabled ()
    {
        optionMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
        optionText.enabled = true;
        imageStart.enabled = true;
        imageExit.enabled = true;
    }
	
    // Método que muestra el menu de salir del juego y desactiva los botones del menu principal
	public void ExitPress ()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        optionText.enabled = false;
        imageStart.enabled = false;
        imageExit.enabled = false;
    }

    // Método que desactiva el menu de salir del juego y reactiva los botones del menu principal
    public void NoPress() 
    {
        quitMenu.enabled = false;
        startText.enabled = true; 
        exitText.enabled = true;
        optionText.enabled = true;
        imageStart.enabled = true;
        imageExit.enabled = true;
    }

    // Método para cargar el primer nivel
    public void StartLevel() 
    {
        Application.LoadLevel("Nivel01"); 
    }

    // Método para salir del juego
    public void ExitGame() 
    {
        Application.Quit(); 
    }
}
