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
	public GameObject audios;

	//public GameObject objetoActual;
	public MoverRotarObjeto3d componenteObjeto;

	public string[] posiciones;
	public string[] rotaciones;
	public string[] escalas;
	public string colorR;
	public string colorG;
	public string colorB;
	public string colorA;
	public string descripcion;
	public int audio;

	public Text TExtoObjeto;
	public InputField CampoDeTexto;

	private int bandera;
	private string ruta;

	public double x, y;

	public GameObject panelMensajes;
	public Text mensajes;
	// Use this for initialization
	public GameObject[] objetos3des;

	private int ban;

	void Awake () {
				Input.location.Start ();
				componenteObjeto= GetComponent<MoverRotarObjeto3d>();

			}

	void Start () {
		bandera = 1;
		ban = 0;
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
//public void datosGPS () {
//			latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
//			longitudObj.text = "Longitud: " + Input.location.lastData.longitude;
//		bandera = 1;
//		}

	 void Update () {
		ruta += opcion;
		tiempo += Time.deltaTime ;
		if (tiempo > 1f /*bandera == 1*/) {
			//Debug.Log("Si entro");
			latitudObj.text = "Latitud: " + Input.location.lastData.latitude;
			longitudObj.text = "Longitud: " + Input.location.lastData.longitude;
			//Debug.Log(Input.location.lastData.latitude);
//			if (componenteObjeto!=null) {
//				if (componenteObjeto.objeto != null) {
//					posicion = componenteObjeto.objeto.transform.position.ToString("G4");
//					rotacion = componenteObjeto.objeto.transform.rotation.ToString("G4");
//					escala = componenteObjeto.objeto.transform.localScale.ToString("G4");
//					colorR = componenteObjeto.objeto.GetComponent<Renderer>().material.color.r.ToString("G4");
//					colorG = componenteObjeto.objeto.GetComponent<Renderer>().material.color.g.ToString("G4");
//					colorB = componenteObjeto.objeto.GetComponent<Renderer>().material.color.b.ToString("G4");
//					colorA = componenteObjeto.objeto.GetComponent<Renderer>().material.color.a.ToString("G4");
//					descripcion = CampoDeTexto.text;
//					//audio = 
//				}
//			}
			tiempo = 0;
		}

		if (Application.loadedLevelName == "Dos") {
			MostrarDatos();
		}
	}

	public void GuardarDatos() {
//		UnityEditor.PrefabUtility.CreatePrefab(ruta,tmp);
		if (panelMensajes!=null) {
			panelMensajes.SetActive(true);
			mensajes.text="ASOCIANDO...";
		}


		var sd = new ServicioDatos ("ejemplo.db");
		objetos3des = GameObject.FindGameObjectsWithTag ("3Dobj");

		for(int x = 0; x < objetos3des.Length;x++){
			if (componenteObjeto!=null) {
				if (componenteObjeto.objeto != null) {
					//Debug.Log(objetos3des[x].name);
					imagen = objetos3des[x].name;
					string nombreNuevo = imagen.Substring(0,imagen.IndexOf("(Clone)"));
					imagen=nombreNuevo.Trim();
					//Debug.Log(nombreNuevo);		
					//char[] c = {')','e','n','o','l','C','('};
					//imagen = imagen.TrimEnd(c);
					//Debug.Log(imagen.TrimEnd(c));

					posicion = objetos3des[x].transform.position.ToString("G4");
					rotacion = objetos3des[x].transform.rotation.ToString("G4");
					escala = objetos3des[x].transform.localScale.ToString("G4");
					colorR = objetos3des[x].GetComponent<Renderer>().material.color.r.ToString("G4");
					colorG = objetos3des[x].GetComponent<Renderer>().material.color.g.ToString("G4");
					colorB = objetos3des[x].GetComponent<Renderer>().material.color.b.ToString("G4");
					colorA = objetos3des[x].GetComponent<Renderer>().material.color.a.ToString("G4");
					descripcion = CampoDeTexto.text;
					//audio = 
				}
			}
			sd.CrearBD (imagen, opcion,  Input.location.lastData.latitude,Input.location.lastData.longitude,posicion,rotacion,escala,colorR,colorG,colorB,colorA,descripcion,audio);
		}
		var dato = sd.ObtenerDato ();

		if (panelMensajes!=null) {
			panelMensajes.SetActive(false);
			mensajes.text="";
		}
	//	aConsol (dato);

	}
	public void MostrarDatos ()

	{

		var sd = new ServicioDatos ("ejemplo.db");
		var datosQ = sd.GetObject (Input.location.lastData.latitude, Input.location.lastData.longitude);

		//Debug.Log (x + " " + y);
		if (ban == 0) {
			ban = 1;
			ToGet (datosQ);
			x = Input.location.lastData.latitude;
			y = Input.location.lastData.longitude;
		}

		if(ban == 1 && Input.location.lastData.latitude != x | Input.location.lastData.longitude != y){
			x = Input.location.lastData.latitude;
			y = Input.location.lastData.longitude;
			ToGet (datosQ);
		}



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
			colorR = datitos.colorR;
			colorG = datitos.colorG;
			colorB = datitos.colorB;
			colorA = datitos.colorA;
			descripcion = datitos.descripcion;
			audio=datitos.audio;
			ToGet(datitos.ToString());
			if (opcion == "2d") 
			{
				MostrarImagen2d(imagen,posicion,rotacion,escala);
			} 
			if(opcion == "3d") 
			{
				MostrarObjecto3d(imagen,posicion,rotacion,escala,colorR,colorB,colorG,colorA,descripcion,audio);
				//Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
			}
		}
	}
	
	public void ToGet(string msg){
		//DebugText.text += System.Environment.NewLine + msg;
		//Debug.Log (msg);
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

	public void MostrarObjecto3d(string nombre,string posicion,string rotacion, string escala,string colorR,string colorG,string colorB,string colorA, string descripcion, int audio) {
		objetos3d = Resources.LoadAll<GameObject> ("3d"); 
		Vector3 posicionIns= new Vector3(0,0,0);
		Quaternion rotacionIns= Quaternion.identity;
		Vector3 escalaIns = new Vector3(0,0,0);
		//Debug.Log("nombre de sql; " + nombre);
		for (int i=0; i< objetos3d.Length; i++) {
			//Debug.Log(objetos3d[i].name );
			if (objetos3d[i].name == nombre)
			{
				//Debug.Log("nombre:" + objetos3d[i].name + "nombre de sql" + nombre);
				//Debug.Log ("encontro3d");
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
				if(audios.GetComponent<AudiAReproducir>().x != null && ban == 1 && Input.location.lastData.latitude != x | Input.location.lastData.longitude != y)
				{
					audios.GetComponent<AudiAReproducir>().x = audio;
				}
//					Debug.Log(posicion.Split(separadores, StringSplitOptions.RemoveEmptyEntries));
				//Debug.Log(rotacion.Split(','));
				GameObject objetoClon = Instantiate(objetos3d [i], posicionIns , rotacionIns) as GameObject;
				objetoClon.transform.localScale = escalaIns;
				objetoClon.GetComponent<Renderer>().material.color = new Color(float.Parse(colorR),float.Parse(colorB),float.Parse(colorG),float.Parse(colorA));
				//Instantiate(objetos3d [i], objetoBase3d.transform.position ,objetoBase3d.transform.rotation);
				objetoBase3d = objetos3d [i];
				if(TExtoObjeto != null && descripcion != null)
					TExtoObjeto.text = descripcion;
			//objetos3d[indice].gameObject = objetoCarrete.objetos3d [indice];
				return;
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

