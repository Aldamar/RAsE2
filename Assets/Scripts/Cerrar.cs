using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cerrar : MonoBehaviour {
	public GameObject ElementoACerrar;
	private int bandera;
	void Start(){
		bandera = 0;
	}
	// Use this for initialization
	public void OnButtonDown()
	{
		if (bandera == 0) {
			ElementoACerrar.SetActive (true);
			bandera = 1;
		} else {
			ElementoACerrar.SetActive (false);
			bandera = 0;
		}
	}
}
