using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PantallaInstrucciones : MonoBehaviour {

	public GameObject panelInstrucciones;
	public TextAsset[] archivos;
	public Text texto;
	public string archivo;
	public int contador=0;
	public GameObject canvas;
	// Use this for initialization
	void Start () {


		panelInstrucciones.SetActive (true);
		texto.text = archivos [contador].text;
	}
	public void boton(){
		panelInstrucciones.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
