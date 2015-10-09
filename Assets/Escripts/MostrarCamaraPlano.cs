using UnityEngine;
using System.Collections;

public class MostrarCamaraPlano : MonoBehaviour {


	public WebCamTexture webcamTexture;

	
	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log(devices[i].name);
		}
		 webcamTexture = new WebCamTexture();
		
		if (devices.Length>0) {
			Renderer renderer = GetComponent<Renderer>();
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
}
