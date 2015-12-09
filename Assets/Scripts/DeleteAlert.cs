using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DeleteAlert : MonoBehaviour {
	public GameObject alerta;
	//public GameObject etapa;
	public void OnMouseDown(){
		alerta.SetActive (false);
		//etapa.SetActive (true);
		//Destroy (alerta);
	}
}
