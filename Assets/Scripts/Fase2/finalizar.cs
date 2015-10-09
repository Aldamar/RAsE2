using UnityEngine;
using System.Collections;

public class finalizar : MonoBehaviour {
	public GameObject texto;
	// Update is called once per frame
	public void OnButtonDown(){
		texto.SetActive (true);
		//Application.LoadLevel ("Fase2");
	}
}
