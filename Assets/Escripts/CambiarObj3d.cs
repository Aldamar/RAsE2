using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SQLite4Unity3d;
public class CambiarObj3d : MonoBehaviour {

	public GameObject objetoCentral;
	public GameObject objetoPadre;
	public CrearCarrete objetoCarrete;
	public GameObject obj;
	public MostrarDatosGPS mostrarDatos;	
	public int indice;

	public GameObject tmp;

	public Vector3 vr;
	// Use this for initialization
	void Start() {
		//objetoPadre = GameObject.Find ("Canvas");
		objetoCarrete = objetoPadre.GetComponent<CrearCarrete>();
		mostrarDatos = objetoPadre.GetComponent<MostrarDatosGPS>();
		vr = new Vector3 (1, 1, 1);
		//tmp = new GameObject();
		//tmp.name = "tmp";
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
		//objetoPadre.GetComponent<MoverRotarObjeto3d>().objeto=objClon;
		objClon.transform.SetParent (tmp.transform);

	}

}
