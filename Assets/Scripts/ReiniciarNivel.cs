using UnityEngine;
using System.Collections;

public class ReiniciarNivel : MonoBehaviour {
	public GameObject panelReinicia;

	void Awake() {
		if (panelReinicia!=null)
			panelReinicia.SetActive(false);
	}

	public void RenNivel(string nombre) {
		panelReinicia.SetActive(true);
		Application.LoadLevel(nombre);
	}


}
