using UnityEngine;
using System.Collections;

public class MouseBorder : MonoBehaviour {
	private double Presinado;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.mousePosition.x >= 1260)
//			Debug.Log("Borde para la imagen");

//		if(Input.GetMouseButtonDown(0))
//			if(Input.mousePosition.x >= 1260)
//				Debug.Log("Borde para la imagen");

//		if(Input.GetMouseButtonDown(0) && Input.mousePosition.x >= 1260)
//				Debug.Log("Borde para la imagen");

		if(Input.GetMouseButton(0)&& Input.mousePosition.x >= 1260)
			Debug.Log("Borde para la imagen");
	}
}
