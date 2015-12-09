using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ImagePanelViewer : MonoBehaviour {
	public Image img;
	public Texture2D[] imgCarrete;
	public Image imgB;
	public int i=0;
	public GameObject cerrar;
	// Use this for initialization
	void Start () {
		imgB = gameObject.GetComponent<Image> ();
		imgCarrete = Resources.LoadAll<Texture2D> ("Fase4");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public Image Viewer;
	public void View(){
		//i = imgB.GetComponent<CargarImagenes>().ind;
		Viewer.gameObject.SetActive (true);
		Rect recto = new Rect (0,0,imgB.sprite.texture.width,imgB.sprite.texture.height);
		Vector2 vec = new Vector2 (0.5f,0.5f);
		img.sprite = Sprite.Create (imgB.sprite.texture,recto,vec);
//		float width, heigth;
//		width = img.rectTransform.sizeDelta.x;
//		heigth = img.rectTransform.sizeDelta.y;
//		Debug.Log (img.rectTransform.sizeDelta.x);
//		cerrar.transform.localPosition = new Vector2 ((width/2)-15,(heigth/2)-15);
	}

	public void Cerrar(){
		Viewer.gameObject.SetActive (false);

	}
}
