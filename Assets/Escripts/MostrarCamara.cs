using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MostrarCamara : MonoBehaviour {

	public RawImage rawimage;
	void Start () 
	{
		WebCamTexture webcamTexture = new WebCamTexture();
		rawimage.texture = webcamTexture;
		rawimage.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}
}
