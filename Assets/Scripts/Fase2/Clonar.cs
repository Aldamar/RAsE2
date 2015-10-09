using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Clonar : MonoBehaviour {
	public Texture2D textura;
	public Canvas kanvas;
	public Image lienzo;

	public Image ejemplo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clonar(){
		int ancho = (int)kanvas.GetComponent<RectTransform>().sizeDelta.x;
		int alto = (int)kanvas.GetComponent<RectTransform>().sizeDelta.y;
		
		textura = new Texture2D (ancho, alto);
		for (int x=0; x<ancho; x++) {
			for (int y=0;y<alto;y++) {
				//textura.SetPixel(x, y, new Color(255, 0, 255));
				textura.SetPixel(x, y, lienzo.sprite.texture.GetPixel(0,0));
			}
		}
		textura.Apply();

		Image[] imagenes = lienzo.GetComponentsInChildren<Image> ();
		for (int z=0; z<imagenes.Length; z++) {
			int imgsx = (int)imagenes[z].transform.position.x;
			int imgsy = (int)imagenes[z].transform.position.y;
			int imgsw = (int)imagenes[z].GetComponent<RectTransform> ().sizeDelta.x;
			int imgsh = (int)imagenes[z].GetComponent<RectTransform> ().sizeDelta.y;
			for (int x=imgsx; x<imgsx+imgsw; x++) {
				for (int y=textura.height-imgsy;y>textura.height-imgsy-imgsh; y--){
					textura.SetPixel(x, y, imagenes[z].sprite.texture.GetPixel(x,y));
				}
			}
			textura.Apply();
		}

		int nancho = Seleccion.width;
		int nalto = Seleccion.height;
		Texture2D tmp = new Texture2D (nancho, nalto);
		for (int x=0; x<nancho; x++) {
			for (int y=0;y<nalto;y++){
				tmp.SetPixel(x,y,new Color(255,0,0));
			}
		}

		Image itmp = Instantiate(ejemplo);
		//itmp.sprite = Sprite.Create (tmp,r,v);
		itmp.transform.SetParent (lienzo.transform);

		Debug.Log ("Clonado");
	}
}
