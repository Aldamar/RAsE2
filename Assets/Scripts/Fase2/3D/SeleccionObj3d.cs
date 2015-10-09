using UnityEngine;
using System.Collections;
using System;
public class SeleccionObj3d : MonoBehaviour {
	public GameObject objeto;
	public MoverRotarObjeto3d moverObj3d;
	public GameObject flecha1, flecha2, flecha3;

	void Start() {
		moverObj3d = objeto.GetComponent<MoverRotarObjeto3d> ();
		flecha1.GetComponent<Renderer> ().material.color = Color.red;
		flecha2.GetComponent<Renderer> ().material.color = Color.green;
		flecha3.GetComponent<Renderer> ().material.color = Color.yellow;
	}
	void OnMouseUp() {
		moverObj3d.objeto = transform.gameObject;
		objeto.GetComponent<SeleccionDeColor>().objeto = transform.gameObject;
		flecha1.GetComponent<RotarX> ().objeto = transform.gameObject;
		flecha2.GetComponent<RotarY> ().objeto = transform.gameObject;
		flecha3.GetComponent<RotarZ> ().objeto = transform.gameObject;
	}

}
