using UnityEngine;
using System.Collections;

public class CargaNivel1 : MonoBehaviour {

	public void Awake() {
		GameObject.Find ("InstruccionesMenu").GetComponent<Canvas> ().enabled = false;
	}

	public void cargaNivel1() {
		Application.LoadLevel("Nivel01");
	}
	public void salir() {
		Application.Quit ();
	}
	public void mostrarInstrucciones() {
		GameObject.Find ("InstruccionesMenu").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("MenuPrincipal").GetComponent<Canvas> ().enabled = false;
		
	}

	public void muestraMenu() {
		GameObject.Find ("InstruccionesMenu").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("MenuPrincipal").GetComponent<Canvas> ().enabled = true;
	}

	public void entraBoton(GameObject objeto) {
		objeto.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 250);
		objeto.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 130);
	}

	public void saleBoton(GameObject objeto) {
		objeto.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, 200);
		objeto.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 100);
	}
}
