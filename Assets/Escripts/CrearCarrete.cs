using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SQLite4Unity3d;

using System.IO;

public class CrearCarrete : MonoBehaviour {

	public GameObject objetoBase;
	public Image objetoBase3d;
	public Sprite[] imagenes;
	public GameObject padre;
	public GameObject padre3d;
	public Texture2D[] imagenes3d;
	public GameObject[] objetos3d;


	public WWW www;
	public string[] nombreObjetos;
	public string[] url;
	public Texture2D[] Img3D;
	public GameObject panel;
	public Image deacticvated;

	// Use this for initialization
	void Start () 
	{



//		imagenes = Resources.LoadAll<Sprite> ("2d");
//
//		objetoBase.GetComponent<Image> ().sprite = imagenes [0];
//
//		for (int i = 1; i < imagenes.Length; i++) {
//			GameObject  objetoClon = Instantiate(objetoBase) as GameObject;
//			objetoClon.GetComponent<Image> ().sprite = imagenes [i];
//			objetoClon.transform.SetParent(padre.transform);
//			objetoClon.transform.position = new Vector2 (objetoBase.transform.position.x + (75*i) , objetoBase.transform.position.y);
//
//		}
	
		imagenes3d = Resources.LoadAll<Texture2D> ("3d");

		
//		objetoBase3d.GetComponent<Image> ().sprite = imagenes3d [0];
//		
//		for (int i = 1; i < imagenes3d.Length; i++) {
//
//			Image  objetoClon = Instantiate(objetoBase3d );
//			objetoClon.GetComponent<Image> ().sprite = imagenes3d [i];
//			objetoClon.transform.SetParent(padre3d.transform);
//			objetoClon.transform.position = new Vector2 (objetoBase3d.transform.position.x + ((objetoClon.GetComponent<RectTransform>().sizeDelta.x * i-1)+20) , objetoBase3d.transform.position.y);
//			objetoClon.GetComponent<CambiarObj3d>().indice = i;
//		}
		objetos3d = Resources.LoadAll<GameObject> ("3d");

		float wid;
		wid = deacticvated.GetComponent<RectTransform> ().sizeDelta.x;
		for(int x=1; x<imagenes3d.Length; x++)
		{
			panel.GetComponent<RectTransform>().sizeDelta = new Vector2 (panel.GetComponent<RectTransform>().sizeDelta.x + wid + wid*0.28f , panel.GetComponent<RectTransform>().sizeDelta.y);
		}
		Image[] images = new Image[imagenes3d.Length];
		Rect r = new Rect (0, 0, imagenes3d [0].width, imagenes3d [0].height);
		Vector2 v = new Vector2 (0.5f,0.5f);
		objetoBase3d.sprite = Sprite.Create (imagenes3d[0], r, v);
		objetoBase3d.GetComponent<CambiarObj3d>().indice = 0;
		for (int x=1; x<imagenes3d.Length; x++) 
		{
			images[x] = Instantiate(objetoBase3d);
			r = new Rect (0, 0, imagenes3d [0].width, imagenes3d [0].height);
			v = new Vector2 (0.5f,0.5f);
			images[x].GetComponent<Image>().sprite = Sprite.Create(imagenes3d[x],r,v);
			images[x].transform.SetParent(panel.transform);
			images[x].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			images[x].GetComponent<CambiarObj3d>().indice = x;
		}

//		
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
