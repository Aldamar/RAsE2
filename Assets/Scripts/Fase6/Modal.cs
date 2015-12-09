using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Modal : MonoBehaviour {
	public Image img;
	public Text tflex, torig;
	public Slider flexibilidad, originalidad;

	public int indice, tipo;
	public Image Fondo;

	public Image ImagenModal;

	// Use this for initialization
	void Start () {
		img = gameObject.GetComponent<Image> ();
		flexibilidad = gameObject.transform.parent.GetComponentsInChildren<Slider> ()[0] as Slider;
		originalidad = gameObject.transform.parent.GetComponentsInChildren<Slider> ()[1] as Slider;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Image Modall;

	public void modal(){
		Modall.gameObject.SetActive (true);
		Rect r;
		Vector2 v = new Vector2 (0.5f,0.5f);
		r = new Rect (0,0,img.sprite.texture.width,img.sprite.texture.height);

		ImagenModal.sprite = Sprite.Create(img.sprite.texture,r,v);

		Fondo.GetComponent<Carga> ().tipo = tipo;
		Fondo.GetComponent<Carga> ().indice = indice;

		//flexibilidad = Fondo.GetComponent<Carga>().flexibilidad;
		//originalidad = Fondo.GetComponent<Carga>().originalidad;
		//flexibilidad = gameObject.transform.parent.GetComponentsInChildren<Slider> ()[0] as Slider;
		//originalidad = gameObject.transform.parent.GetComponentsInChildren<Slider> ()[1] as Slider;

		//Modall.gameObject.GetComponentsInChildren<Slider> () [0] =flexibilidad;
		//Modall.gameObject.GetComponentsInChildren<Slider> () [1] = originalidad;
		Debug.Log("valor flexibilidad" + flexibilidad.value);
		Debug.Log("valor originalidad" + originalidad.value);
	//	Modall.gameObject.GetComponentsInChildren<Slider> () [0].value =(int)flexibilidad.value;
	//	Modall.gameObject.GetComponentsInChildren<Slider> () [1].value =(int)originalidad.value;
		/*
		flexibilidad.value = gameObject.transform.parent.GetComponentsInChildren<Slider> () [0].value;
		tflex.text = "Flexibilidad: " + (int)flexibilidad.value;
		originalidad.value = gameObject.transform.parent.GetComponentsInChildren<Slider> () [1].value;
		torig.text = "Originalidad: " + (int)originalidad.value;

		Modall.gameObject.GetComponentsInChildren<Slider> () [0].value =(int)flexibilidad.value;
		Modall.gameObject.GetComponentsInChildren<Slider> () [1].value =(int)originalidad.value;
		*/
		Fondo.GetComponent<Carga>().flexibilidad.value =(int)flexibilidad.value;
		Fondo.GetComponent<Carga>().originalidad.value =(int)originalidad.value;

	}
}