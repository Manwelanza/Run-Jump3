using UnityEngine;
using System.Collections;

public class CargaNivel1 : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 4, 200, 50), "Inicio")) {
			Application.LoadLevel("Nivel01");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 4 + 100, 200, 50), "Instrucciones")) {
			// TODO: Hacer que se vean las instrucciones
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 4 + 200, 200, 50), "Creditos")) {
			// TODO: Hacer que se vean los "Creditos" (nombre de los autores  y tal)
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 4 + 300, 200, 50), "Salir")) {
			Application.Quit();
			// TODO: Mirar por que no funciona!
		}

	}

}
