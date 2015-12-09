using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Pantalla : MonoBehaviour {
	private string ruta;
	public int x;
	public GameObject panelMensajes;
	public Text mensajes;
	// Use this for initialization
	void Start () {

		ruta = Application.persistentDataPath;
		ruta += "/Resources/Capturas/";
		if (!Directory.Exists (ruta)) {
			Directory.CreateDirectory (ruta);
		}
		x = 1;
	}
	
	public void gd()
	{
		if (panelMensajes!=null) {
			panelMensajes.SetActive(true);
			mensajes.text="CAPTURANDO...";
		}
		//Application.CaptureScreenshot (ruta + x + ".png");
		Application.CaptureScreenshot( x + ".png");
		x++;
		if (panelMensajes!=null) {
			panelMensajes.SetActive(false);
			mensajes.text="CAPTURANDO...";
		}
	}
}
