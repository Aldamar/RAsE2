using UnityEngine;
using System.Collections;

public class LoadScne : MonoBehaviour {
	public string NombreEscena;

	public void OnButtonDown()
	{
		Application.LoadLevel (NombreEscena);
	}
}
