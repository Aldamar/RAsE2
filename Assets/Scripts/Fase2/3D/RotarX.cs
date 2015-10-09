using UnityEngine;
using System.Collections;
using System;
public class RotarX : MonoBehaviour {
	public GameObject objeto;
	
	void OnMouseUp() {
		objeto.transform.Rotate (Vector3.up*-5);
	}
}
