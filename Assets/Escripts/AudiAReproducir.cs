using UnityEngine;
using System.Collections;

public class AudiAReproducir : MonoBehaviour {
	public GameObject canvas;
	public int x;
	private AudioSource source;
	private AudioClip clip;
	void Awake(){
		source = GetComponent<AudioSource>();
	}
	public void OnButtonDown(){

		Debug.Log ("audio/"+canvas.GetComponent<CargarAudios>().clips [x].name);
		clip = Resources.Load<AudioClip> ("audio/"+canvas.GetComponent<CargarAudios>().clips [x].name);
		source.clip = clip;
		source.Play (); 
		canvas.GetComponent<MostrarDatosGPS> ().audio = x;
	}
}
