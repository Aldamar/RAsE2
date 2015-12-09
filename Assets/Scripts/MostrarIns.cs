using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MostrarIns : MonoBehaviour {

	public GameObject pantalla;
	public TextAsset archivo;
	public Text texto;
	public int nivel;
	// Use this for initialization
	void Start () {
		pantalla.SetActive (true);
		texto.text = archivo.text;
		Debug.Log(nivel);
		//MenuNavegar()
	}
	public void Oculta() {
		pantalla.SetActive (false);
	}

	public void OnButtonDown()
	{
		if (nivel == 0) {
			Application.LoadLevel("iniciar");
		} else {
			Application.LoadLevel("Fase" + nivel);
		}
	}
}
