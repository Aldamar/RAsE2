using UnityEngine;
using System.Collections;
using System;
public class RotarY : MonoBehaviour {
	public GameObject objeto;
	void OnMouseUp() {
		objeto.transform.Rotate (Vector3.right*-5);
	}
}
