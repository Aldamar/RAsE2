using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LINK1 : MonoBehaviour {

	public GameObject panelMensajes;
	public Text mensajes;

	public void configurar ()
	{
		if (panelMensajes!=null) {
			panelMensajes.SetActive(true);
			mensajes.text="CARGANDO...";
		}
		Application.LoadLevel("Uno");
	}

	public void iniciar()
	{
		if (panelMensajes!=null) {
			panelMensajes.SetActive(true);
			mensajes.text="ACCEDIENDO...";
		}
		Application.LoadLevel ("Dos");
	}

	public void volver ()
	{
		if (panelMensajes!=null) {
			panelMensajes.SetActive(true);
			mensajes.text="CARGANDO...";
		}
		Application.LoadLevel ("Menu");
	}

	public void vuforia ()
	{
		Application.LoadLevel ("Vuforia");
	}
}
