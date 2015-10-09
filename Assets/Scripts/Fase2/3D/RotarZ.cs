using UnityEngine;
using System.Collections;
using System;
public class RotarZ : MonoBehaviour {
	public GameObject objeto;
	void OnMouseUp() {
		objeto.transform.Rotate (Vector3.back*5);
	}
}
