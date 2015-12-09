using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class Evaluador : MonoBehaviour {

	//public GameObject panelEvaluador;
	public InputField usuario;
	public string codigoEvaluador;
	public string nombreEquipo;
	public string[] nombreInte = new string[5];

	public GameObject fondo;
	public Carga cargaScript;
	public string ruta;
	public string  texto="";

	public Text mensaje;
	// Use this for initialization

	void Start() {
		if (fondo!=null)
			cargaScript = fondo.GetComponent<Carga>() as Carga;
		codigoEvaluador="0";
		nombreEquipo= PlayerPrefs.GetString ("NombreEquipo");
	//	Debug.Log(PlayerPrefs.GetInt("IntegrantesTotal"));
		for (int i = 0; i <= PlayerPrefs.GetInt("IntegrantesTotal");i++) {
			if (PlayerPrefs.GetString ("Integrante"+(i+1))!="") {
				nombreInte[i] =PlayerPrefs.GetString ("Integrante"+(i+1));
			}
		}
		
		ruta = Application.persistentDataPath;
		ruta += "/Resources/Fase6/";

		if (Directory.Exists (ruta) == false) {
			Directory.CreateDirectory (ruta);
		}

		ruta += "Evaluacion.txt";
		if (File.Exists (ruta) == false) {
			File.Create (ruta);
		}
		
	}
	// Update is called once per frame
	public void GuardaCodigoEvaluador() {
		codigoEvaluador=usuario.text;	
	}

	public void OcultaPanel() {
		if (usuario.text != "") {
			gameObject.SetActive(false);
			mensaje.text="";
			cargaScript.nombre.text = "EQUIPO: " + nombreEquipo;
		} else {
			mensaje.text ="FAVOR DE CAPTURAR CÓDIGO";
		}

		//panelEvaluador.SetActive(false);
	}

	public void MuestraPanel() {
		gameObject.SetActive(true);
		//panelEvaluador.SetActive(true);
	}

	public void GuardaEvaluacion(){

		texto += "Equipo: " +  nombreEquipo + " Evaluado por codigo: " + codigoEvaluador + "\n";

		//flexibilidad grupal
		for (int i = 0; i<cargaScript.ifgrupo.Length;i++) {
			texto+="imagen " + (i+1) + "grupal en flexiblidad, valor de: " + cargaScript.ifgrupo[i] + "\n";
		}
		//origininalidad grupal
		for (int i = 0; i<cargaScript.iogrupo.Length;i++) {
			texto+="imagen " + (i+1) + "grupal en originalidad, valor de: " + cargaScript.iogrupo[i] + "\n";
		}
		//flexibiblidad individual
		for (int i = 0; i<cargaScript.ifindividual.Length;i++) {
			texto+="imagen " + (i+1) + "individual en flexiblidad, valor de: " + cargaScript.ifindividual[i] + "\n";
		}
		//origininalidad individual
		for (int i = 0; i<cargaScript.ioindividual.Length;i++) {
			texto+="imagen " + (i+1) + "individual en originalidad, valor de: " + cargaScript.ioindividual[i] + "\n";
		}

		File.AppendAllText(ruta,texto);
		//tmp.text = File.ReadAllText (ruta) + texto + " ";
		//File.WriteAllText(ruta,tmp.text,System.Text.Encoding.UTF8);
		//File.Open(ruta,FileMode.OpenOrCreate);
		//File.AppendAllText(ruta,tmp.text);

	}

	public void RegresaMenu() {
		Application.LoadLevel("iniciar");
	}
}
