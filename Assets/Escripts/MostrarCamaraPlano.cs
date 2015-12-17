using UnityEngine;
using System.Collections;

public class MostrarCamaraPlano : MonoBehaviour {


	public WebCamTexture webcamTexture;
	public int bandera;
	WebCamDevice[] devices;
	
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log(devices[i].name);
		}
		devices = WebCamTexture.devices;

		 webcamTexture = new WebCamTexture();

		if (devices.Length>0) {
			Renderer renderer = GetComponent<Renderer>();
			webcamTexture.deviceName = devices[0].name;
			renderer.material.mainTexture = webcamTexture;
			if (webcamTexture.isPlaying) {
				webcamTexture.Stop();
			}


			webcamTexture.Play();
		}

	}

	void OnDestroy() {
		Debug.Log("entra destruir");
		webcamTexture.Stop();
	}

	public void OnButtonDown(){
		if (bandera == 1) {
			Renderer renderer = GetComponent<Renderer>();
			webcamTexture.deviceName = devices[1].name;
			renderer.material.mainTexture = webcamTexture;
			if (webcamTexture.isPlaying) {
				webcamTexture.Stop();
			}
			
			
			webcamTexture.Play();
		}
		if (bandera == 0) {
			Renderer renderer = GetComponent<Renderer>();
			webcamTexture.deviceName = devices[0].name;
			renderer.material.mainTexture = webcamTexture;
			if (webcamTexture.isPlaying) {
				webcamTexture.Stop();
			}
			
			
			webcamTexture.Play();
		}
	}
}
