using UnityEngine;
using System.Collections;

public class AvanzarFase : MonoBehaviour {
	public int contadorFase;
	public GameObject carga;
	public void OnButtonDown(){
		contadorFase++;
		Application.LoadLevel ("Fase"+contadorFase);
	}
	public void cargando()
	{
		carga.SetActive (true);
	}
}
