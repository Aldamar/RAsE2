using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using SQLite4Unity3d;


public class BDExistente : MonoBehaviour {

	public Text testdb;

	// Use this for initialization
	void Start () {
		var sd = new ServicioDatos ("ejemplo.db");
	//sd.CrearBD ();
		var dato = sd.ObtenerDato ();
		aConsol (dato);
	
	}

	private void aConsol(IEnumerable<datos> daatos){
		foreach (var datos in daatos) {
			aConsol(datos.ToString());
		}
	}
	
	private void aConsol(string msg){
		testdb.text += System.Environment.NewLine + msg;
		Debug.Log (msg);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
