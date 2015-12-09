using UnityEngine;
using System.Collections;
using System.IO;

public class GuardarDatos : MonoBehaviour {
	public GameObject correcta;
	// Use this for initialization
	public string ruta;
	public string  texto="";

	void Start(){
		ruta = Application.persistentDataPath;
		ruta += "/Resources/Fase5/";
		if (!Directory.Exists (ruta)) {
			Directory.CreateDirectory (ruta);
		}
		//Directory.CreateDirectory (ruta);
		ruta += "Evaluacion.txt";
		if (File.Exists (ruta) == false) {
			File.Create (ruta);
		}

	}

	public void GuardaValores() {
		if (File.Exists (ruta) == false) {
			File.Create (ruta);
		}

		File.WriteAllText(ruta,texto);
	//	File.WriteAllText ("Evaluacion.txt", texto);

	}
}