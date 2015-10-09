using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using SQLite4Unity3d;

public class DatosVuforia : MonoBehaviour {
	public Text latitudObj;
	public Text longitudObj;
	public GameObject Base3d;
	public Image objetoBase;
	public GameObject[] objetos3d;
	public Sprite[] imagen2d;
	public int indice;
	public float tiempo = 0f;
	public string opcion = "2d";
	public string imagen = "imagen";



	// Use this for initialization
	void Start () {
		Input.location.Start ();
	}
	

	public void datosGPS () {
		latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
		longitudObj.text = "Longitud: " + Input.location.lastData.longitude;
	}
	
	void Update () {
		tiempo += Time.deltaTime;
		if (tiempo > 0.5f) {
			//longitudObj.text = "Longitd: " + Input.location.lastData.longitude;
			//latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
			tiempo = 0;
		}
	}
	public void MostrarDatos ()
		
	{
		var sd = new ServicioDatos ("ejemplo.db");
		var datosQ = sd.GetObject (Input.location.lastData.latitude, Input.location.lastData.longitude);
		ToGet (datosQ);
		
		Debug.Log ("Entro");
	}
	public void ToGet(IEnumerable<datos> dat){
		foreach (var datitos in dat) {
			imagen=datitos.imagen;
			opcion=datitos.tipo;
			ToGet(datitos.ToString());
			if (opcion == "2d") {
				MostrarImagen2d(imagen);
			} else {
				MostrarObjecto3d(imagen);
				//Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
			}
		}
	}
	
	public void ToGet(string msg){
		//DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}

		public void MostrarImagen2d(string nombre) {
			imagen2d = Resources.LoadAll<Sprite> ("2d");
			for (int i=0; i< imagen2d.Length; i++) {
				if (imagen2d[i].name == nombre)
				{
					Debug.Log ("encontro2d");
					objetoBase.sprite = imagen2d[i];
				}
			}
			
			
		}
		
		public void MostrarObjecto3d(string nombre) {
			objetos3d = Resources.LoadAll<GameObject> ("3d"); 
			for (int i=0; i< objetos3d.Length; i++) {
				if (objetos3d[i].name == nombre)
				{
					Debug.Log ("encontro3d");
					Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
      				//Instantiate(objetos3d [i], Base3d.transform.position ,Base3d.transform.rotation);
				    Instantiate(objetos3d [i], new Vector3(200,550,100) , new Quaternion(0,0,0,0));
					Base3d = objetos3d [i];
					//objetos3d[indice].gameObject = objetoCarrete.objetos3d [indice];
				}
				
			}
			
		}



}
