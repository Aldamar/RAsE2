using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SQLite4Unity3d;
using System.IO;
using System;


public class CambiarObj3d : MonoBehaviour {

	public GameObject objetoCentral;
	public GameObject objetoPadre;
	public CrearCarrete objetoCarrete;
	public GameObject obj;
	public MostrarDatosGPS mostrarDatos;	
	public int indice;

	public GameObject tmp;

	public Vector3 vr;
	//...................GeekerX
	public WWW www;
	public string[] nombreObjetos;
	public string[] url;
	public GameObject[] Objetos3D;
	public GameObject canvas;
	//...................GeekerX
	// Use this for initialization
	void Start() {
		//objetoPadre = GameObject.Find ("Canvas");
		objetoCarrete = objetoPadre.GetComponent<CrearCarrete>();
		mostrarDatos = objetoPadre.GetComponent<MostrarDatosGPS>();
		vr = new Vector3 (1, 1, 1);
		//tmp = new GameObject();
		//tmp.name = "tmp";

//		//............................................GeekerX
//		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath+"/Resources/3d/");
//		FileInfo[] info = dir.GetFiles("*.fbx");
//		int z = 0;
//		foreach (FileInfo f in info) {
//			//f.Name.TrimEnd(".fbx");
//			z++;
//		}
//		char[] charsToTrim = {'x','b','f','.'};
//		nombreObjetos = new string[z];
//		url = new string[z];
//		z = 0;
//		foreach (FileInfo f in info) {
//			//f.Name.TrimEnd(".fbx");
//			nombreObjetos[z] = f.Name.TrimEnd(charsToTrim); 
//			Debug.Log(nombreObjetos[z]);
//			z++;
//		}
//		Debug.Log ("------------------------------------" + z);
//		for(int i = 0; i < z; i++) {
//			url[i] = "file://"+Application.persistentDataPath+"/Resources/3d/" + nombreObjetos[i] + ".fbx";
//			Debug.Log(url[i]);
//			www = new WWW(url[i]);
//			if ((int)www.texture.width != 8)
//			{
//				if (www.texture.width!=8)
//					yield return www;
//				else 
//					break;
//			}
//		}
//
//		Debug.Log ("Se generar las url");
//		Objetos3D = new GameObject[z];
//		z = 0;
//		while (z < Objetos3D.Length)
//		{
//			www = new WWW(url[z]);
//			yield return www;
//			if (www.error != null)
//				throw new Exception(www.error);
//			AssetBundle assetBundle = www.assetBundle;
//			Debug.Log(assetBundle.name);
//			Objetos3D [z] = assetBundle.LoadAsset(nombreObjetos[z],typeof (T)) as GameObject;
//			//Objetos3D [z] = (GameObject)www;
//			z++;
//		}
//		//......................................................GeekerX
	}

	// Update is called once per frame
	public void CambiarObjeto () {
		Debug.Log ("entra cambia objeto");
		//Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
		GameObject objClon= Instantiate(objetoCarrete.objetos3d [indice], vr,objetoCentral.transform.rotation) as GameObject;
		objetoCentral = objetoCarrete.objetos3d [indice];
		objClon.tag = "3Dobj";
		mostrarDatos.imagen = objetoCarrete.objetos3d [indice].name;
		//mostrarDatos.imagen = objetoPadre.name;
		//REVISAR OBJETO ACTUAL
		objClon.AddComponent<D3D> ();
		objClon.AddComponent<SeleccionObj3d> ();
		objClon.GetComponent<SeleccionObj3d> ().moverObj3d = objetoPadre.GetComponent<MoverRotarObjeto3d> ();
		objClon.GetComponent<SeleccionObj3d> ().objeto = objetoPadre;
		objetoPadre.GetComponent<MoverRotarObjeto3d> ().objeto = objClon;
		canvas.GetComponent<SeleccionDeColor> ().objeto = objClon;
		//objetoPadre.GetComponent<MoverRotarObjeto3d>().objeto=objClon;
		objClon.transform.SetParent (tmp.transform);


	}

}
