using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;


public class MostrarDatosGPS : MonoBehaviour {
	public Text latitudObj;
	public Text longitudObj;
	public float tiempo = 0f;
	public string opcion = "3d";
	public string imagen = "imagen";
	public Text botonOpcion;
	public GameObject central ;
	public Sprite[] imagen2d;
	public Sprite[] imagen3d;
	public Image objetoBase;
	public GameObject objetoBase3d;
	public GameObject[] objetos3d;
	public int indice;
	public string posicion = "0,0,0";
	public string rotacion = "0,0,0";
	public string escala = "0,0,0";
	public GameObject tmp;

	//public GameObject objetoActual;
	public MoverRotarObjeto3d componenteObjeto;

	public string[] posiciones;
	public string[] rotaciones;
	public string[] escalas;


	private int bandera;
	private string ruta;
	// Use this for initialization
	void Awake () {
		Input.location.Start ();
		componenteObjeto= GetComponent<MoverRotarObjeto3d>();

	}

	void Start()
	{
		ruta = Application.persistentDataPath;
		ruta += "/Resources/";
		if (!Directory.Exists (ruta+"3d")) {
			Directory.CreateDirectory (ruta+"3d");
		}
		if (!Directory.Exists (ruta+"2d")) {
			Directory.CreateDirectory (ruta+"2d");
		}
	}
	
	// Update is called once per frame
public void datosGPS () {
//			latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
//			longitudObj.text = "Longitud: " + Input.location.lastData.longitude;
		bandera = 1;
		}

	 void Update () {
		ruta += opcion;
		//tiempo += Time.deltaTime ;
		if (/*tiempo > 0.5f*/ bandera == 1) {
			latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
			longitudObj.text = "Longitud: " + Input.location.lastData.longitude;
			if (componenteObjeto!=null) {
				if (componenteObjeto.objeto != null) {
					posicion = componenteObjeto.objeto.transform.position.ToString("G4");
					rotacion = componenteObjeto.objeto.transform.rotation.ToString("G4");
					escala = componenteObjeto.objeto.transform.localScale.ToString("G4");;
				}
			}
			tiempo = 0;
		}
	}

	public void GuardarDatos() {
//		UnityEditor.PrefabUtility.CreatePrefab(ruta,tmp);
		var sd = new ServicioDatos ("ejemplo.db");
		sd.CrearBD (imagen, opcion,  Input.location.lastData.latitude,Input.location.lastData.longitude,posicion,rotacion,escala);
//		var dato = sd.ObtenerDato ();
	//	aConsol (dato);

	}
	public void MostrarDatos ()

	{
		var sd = new ServicioDatos ("ejemplo.db");
		var datosQ = sd.GetObject (Input.location.lastData.latitude, Input.location.lastData.longitude);
		ToGet (datosQ);

		Debug.Log ("Entro");
	}
	public void CambiarTipo() {
		if (opcion == "2d") {
			opcion = "3d";
			botonOpcion.text = "2d";
			central.SetActive(false);

			GetComponent<CrearCarrete>().ActivarCarrete(false);


		} else {
			opcion = "2d";		
			botonOpcion.text = "3d";
			central.SetActive(true);
			GetComponent<CrearCarrete>().ActivarCarrete(true);

		}
	}

	public void ToGet(IEnumerable<datos> dat){
		foreach (var datitos in dat) {
			imagen=datitos.imagen;
			opcion=datitos.tipo;
			posicion=datitos.posicion;
			rotacion=datitos.rotacion;
			escala=datitos.escala;
			ToGet(datitos.ToString());
			if (opcion == "2d") 
			{
				MostrarImagen2d(imagen,posicion,rotacion,escala);
			} 
			if(opcion == "3d") 
			{
				MostrarObjecto3d(imagen,posicion,rotacion,escala);
				//Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
			}
		}
	}
	
	public void ToGet(string msg){
		//DebugText.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}
 

	public void MostrarImagen2d(string nombre,string posicion,string rotacion, string escala) {
		imagen2d = Resources.LoadAll<Sprite> ("2d");
		for (int i=0; i< imagen2d.Length; i++) {
			if (imagen2d[i].name == nombre)
			{
				Debug.Log ("encontro2d");
				objetoBase.sprite = imagen2d[i];
			}
		}

		  	
	}

	public void MostrarObjecto3d(string nombre,string posicion,string rotacion, string escala) {
		objetos3d = Resources.LoadAll<GameObject> ("3d"); 
		Vector3 posicionIns= new Vector3(0,0,0);
		Quaternion rotacionIns= Quaternion.identity;
		Vector3 escalaIns = new Vector3(0,0,0);

		for (int i=0; i< objetos3d.Length; i++) {
			if (objetos3d[i].name == nombre)
			{
				Debug.Log ("encontro3d");
				Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
				string[] separadores = {",", "(", ")", " "};
				if (posicion!=null) {
					posiciones = posicion.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
					posicionIns = new Vector3(float.Parse(posiciones[0]),float.Parse(posiciones[1]),float.Parse(posiciones[2]));
				}
				if (rotacion!=null) {
					rotaciones=rotacion.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
					rotacionIns = new Quaternion(float.Parse(rotaciones[0]),float.Parse(rotaciones[1]),float.Parse(rotaciones[2]),float.Parse(rotaciones[3]));
				}
				if (escala!=null) {
					escalas = escala.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
					escalaIns = new Vector3(float.Parse(escalas[0]),float.Parse(escalas[1]),float.Parse(escalas[2]));
				}
//					Debug.Log(posicion.Split(separadores, StringSplitOptions.RemoveEmptyEntries));
				//Debug.Log(rotacion.Split(','));
				GameObject objetoClon = Instantiate(objetos3d [i], posicionIns , rotacionIns) as GameObject;
				objetoClon.transform.localScale = escalaIns;
				//Instantiate(objetos3d [i], objetoBase3d.transform.position ,objetoBase3d.transform.rotation);
				objetoBase3d = objetos3d [i];
			//objetos3d[indice].gameObject = objetoCarrete.objetos3d [indice];
			}
		
		}

	}
//public void act ()
//{
//		tiempo += Time.deltaTime ;
//		if (tiempo < 2)
//	latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
//		longitudObj.text = "Latitud: " + Input.location.lastData.longitude;
//		tiempo = 0;
//}
}

