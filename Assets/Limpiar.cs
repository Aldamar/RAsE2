using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Limpiar : MonoBehaviour {

	public GameObject panelMensajes;
	public Text mensajes;

	public void OnButtonDown(){
		panelMensajes.SetActive(true);
		mensajes.text="LIMPIANDO...";
		Application.LoadLevel("Uno");
	}
}
