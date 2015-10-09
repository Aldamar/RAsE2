using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SQLite4Unity3d;

public class CrearCarrete : MonoBehaviour {

	public GameObject objetoBase;
	public GameObject objetoBase3d;
	public Sprite[] imagenes;
	public GameObject padre;
	public GameObject padre3d;
	public Sprite[] imagenes3d;
	public GameObject[] objetos3d;
	// Use this for initialization
	void Start () {
		imagenes = Resources.LoadAll<Sprite> ("2d");

		objetoBase.GetComponent<Image> ().sprite = imagenes [0];

		for (int i = 1; i < imagenes.Length; i++) {
			GameObject  objetoClon = Instantiate(objetoBase) as GameObject;
			objetoClon.GetComponent<Image> ().sprite = imagenes [i];
			objetoClon.transform.SetParent(padre.transform);
			objetoClon.transform.position = new Vector2 (objetoBase.transform.position.x + (75*i) , objetoBase.transform.position.y);

		}
	
		imagenes3d = Resources.LoadAll<Sprite> ("3d");

		
		objetoBase3d.GetComponent<Image> ().sprite = imagenes3d [0];
		
		for (int i = 1; i < imagenes3d.Length; i++) {

			GameObject  objetoClon = Instantiate(objetoBase3d ) as GameObject;
			objetoClon.GetComponent<Image> ().sprite = imagenes3d [i];
			objetoClon.transform.SetParent(padre3d.transform);
			objetoClon.transform.position = new Vector2 (objetoBase3d.transform.position.x + (120*i) , objetoBase3d.transform.position.y);
			objetoClon.GetComponent<CambiarObj3d>().indice = i;
		}
		objetos3d = Resources.LoadAll<GameObject> ("3d"); 
	   }


	public void ActivarCarrete(bool dos) {
		if (dos) {
			padre.SetActive (true);
			padre3d.SetActive (false);
		} else {
			padre.SetActive (false);
			padre3d.SetActive (true);
		}
	}


}
