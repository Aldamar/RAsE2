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
	
	public Vector3 vr;
	// Use this for initialization
	void Start() {
		objetoPadre = GameObject.Find ("Canvas");
		objetoCarrete = objetoPadre.GetComponent<CrearCarrete>();
		mostrarDatos = objetoPadre.GetComponent<MostrarDatosGPS>();
		vr = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	public void CambiarObjeto () {
		Debug.Log ("entra cambia objeto");
		//Destroy(GameObject.FindGameObjectWithTag ("objeto3d"));
		GameObject objClon= Instantiate(objetoCarrete.objetos3d [indice], vr,objetoCentral.transform.rotation) as GameObject;
		objetoCentral = objetoCarrete.objetos3d [indice];
		mostrarDatos.imagen = objetoCarrete.objetos3d [indice].name;
		//mostrarDatos.imagen = objetoPadre.name;
		//REVISAR OBJETO ACTUAL

		objetoPadre.GetComponent<MoverRotarObjeto3d>().objeto=objClon;

	}

}
