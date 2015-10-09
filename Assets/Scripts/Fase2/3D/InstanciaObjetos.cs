using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstanciaObjetos : MonoBehaviour {
	GameObject tmp;
	public GameObject canvas;
	public GameObject cubo, esfera, cilindro, capsula;

	public void OnButtonPressCubo(){
		tmp = Instantiate(cubo);
		StartCoroutine(Espera(0.01F));
	}

	public void OnButtonPressEsfera(){
		tmp = Instantiate(esfera);
		StartCoroutine(Espera(0.01F));
	}

	public void OnButtonPressClinindro(){
		tmp = Instantiate(cilindro);
		StartCoroutine(Espera(0.01F));
	}

	public void OnButtonPressCapsula(){
		tmp = Instantiate(capsula);
		StartCoroutine(Espera(0.01F));
	}

	IEnumerator Espera(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		tmp.transform.position = new Vector3 (0, 0, -10);
		tmp.GetComponent<SeleccionObj3d> ().objeto = canvas;
	}
}
