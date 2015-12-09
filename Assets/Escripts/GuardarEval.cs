using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class GuardarEval : MonoBehaviour {

//	public InputField usuario;
//	public string codigoEvaluador;
//	public string nombreEquipo;
	public GameObject panel;
	public GameObject canvas;
	public string ruta;
	public string  texto="";
	public Slider O, F;
	public InputField evaluador;

	// Use this for initialization
	void Start () {
		ruta = Application.persistentDataPath;
		if (Directory.Exists (ruta) == false) {
			Directory.CreateDirectory (ruta);
		}
		ruta += "Evaluacion.txt";
		if (File.Exists (ruta) == false) {
			File.Create (ruta);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonDown()
	{
		ConcatEvaluacion ();
		renewValues ();
		panel.SetActive (false);
	}
	private void ConcatEvaluacion(){
		texto += "Nombre del evaluadro: " + evaluador.text + "\n";
		texto += "Imagen coordenadas: (x, " +  canvas.GetComponent<MostrarDatosGPS>().x + ") y (y, " +canvas.GetComponent<MostrarDatosGPS>().y + ") \n";
		//flexibiblidad individual

		texto += "Originaldiad: " + O.value + ", \n";

		//origininalidad individual

		texto += "Flexibilidad: " + F.value + ", \n";
		texto += "-------------------------------------------\n";
		
		File.AppendAllText(ruta,texto);
		//tmp.text = File.ReadAllText (ruta) + texto + " ";
		//File.WriteAllText(ruta,tmp.text,System.Text.Encoding.UTF8);
		//File.Open(ruta,FileMode.OpenOrCreate);
		//File.AppendAllText(ruta,tmp.text);
	}

	private void renewValues(){
		O.value = 0;
		F.value = 0;
	}


}
