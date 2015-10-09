using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SQLite4Unity3d;

public class CambiarImagen : MonoBehaviour {

	public Image imagenCentral;
	public GameObject objetoPadre;
	public MostrarDatosGPS mostrarDatos;

	void Start() {
		objetoPadre = GameObject.Find ("Canvas");
		mostrarDatos = objetoPadre.GetComponent<MostrarDatosGPS>();
	}
	// Update is called once per frame
	public void CambiaImg () {
		Sprite objSprite = GetComponent<Image> ().sprite;
		imagenCentral.sprite = objSprite;
		if (objSprite != null) {
			mostrarDatos.imagen = objSprite.name;
			mostrarDatos.imagen = objSprite.name;
		}
	
	}

}
