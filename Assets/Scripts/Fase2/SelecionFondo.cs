using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelecionFondo : MonoBehaviour {

	public Image Fondo, textura;
	public GameObject Panelfondo;
	public void OnMouseDown() {
		Fondo.sprite = textura.sprite;
		Fondo.color = Color.white;
	}

	public void OnFondoDown(){
		if (Panelfondo.activeSelf == true) {
			Panelfondo.SetActive (false);
		} else {
			Panelfondo.SetActive(true);
		}
	}
	public void Cerrar(){
		Panelfondo.SetActive (false);
	}
}
