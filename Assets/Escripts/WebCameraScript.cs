using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;


public class WebCameraScript : MonoBehaviour {
	
	public GUITexture myCameraTexture;
	public WebCamTexture webcamTexture;
	public Image imagen;

	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log(devices[i].name);
		}
		webcamTexture = new WebCamTexture();

		if (GetComponent<Image>()!= null) {
			imagen = GetComponent<Image>();
			imagen.material.mainTexture=webcamTexture;
		}
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = webcamTexture;



		//CanvasRenderer renderer2 = GetComponent<CanvasRenderer>();
		//renderer2.SetMaterial(new Material(Shader.Find("Specular")),webcamTexture);
		webcamTexture.Play();
		// Checks how many and which cameras are available on the device
		

	}
	
	public void ShowCamera()
	{
		//myCameraTexture.GetComponent<GUITexture>().enabled = true;
		webcamTexture.Play();
	}
	
	public void HideCamera()
	{
		
		//myCameraTexture.GetComponent<GUITexture>().enabled = false;
		webcamTexture.Stop();
	
	}
	void OnUpdate()
	{
		
		
	
	}
	
	void OnGUI()
	{
			
		if(GUI.Button(new Rect(0,0,100,100),"ON/OFF"))
		{
			if(webcamTexture.isPlaying)
				this.HideCamera();
			else
				this.ShowCamera();
		}
		
		
	}
	
	   
}
