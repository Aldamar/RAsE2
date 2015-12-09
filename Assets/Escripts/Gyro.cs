using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour {
	public GameObject camara;
	Gyroscope Giroscopio;
	public Rigidbody rb;
	// Use this for initialization

	private static Quaternion ConvertRotation(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}

	private Quaternion GetRotFix()
	{
		if (Screen.orientation == ScreenOrientation.Portrait)
			return Quaternion.identity;
		if (Screen.orientation == ScreenOrientation.LandscapeLeft
		    || Screen.orientation == ScreenOrientation.Landscape)
			return Quaternion.Euler(0, 0, -90);
		if (Screen.orientation == ScreenOrientation.LandscapeRight)
			return Quaternion.Euler(0, 0, 90);
		if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
			return Quaternion.Euler(0, 0, 180);
		return Quaternion.identity;
	}

	void Start () {
		Input.gyro.enabled = true; //Habilitar el giroscopio
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	/*void Update () {

		camara.transform.Rotate (Vector3.up,(Input.gyro.rotationRate.x*Input.gyro.userAcceleration.x));
		camara.transform.Rotate (Vector3.back,(Input.gyro.rotationRate.y*Input.gyro.userAcceleration.y));
		camara.transform.Rotate (Vector3.left,(Input.gyro.rotationRate.z*Input.gyro.userAcceleration.z));
		camara.transform.Translate (Vector3.,(Input.gyro.rotationRate.x*Input.gyro.userAcceleration.x));
		camara.transform.Translate (Vector3.back,(Input.gyro.rotationRate.y*Input.gyro.userAcceleration.y));
		camara.transform.Translate (Vector3.left,(Input.gyro.rotationRate.z*Input.gyro.userAcceleration.z));
	}*/
	void FixedUpdate ()
	{
		transform.rotation = ConvertRotation(Input.gyro.attitude) * GetRotFix();

		/*camara.transform.rotation = Input.gyro.attitude;
		camara.GetComponent<Rigidbody> ().AddForce (Input.gyro.userAcceleration);*/
		Debug.Log("Rotacion: "+Input.gyro.attitude); //Rotación del giroscopio
		Debug.Log("Aceleracion: "+Input.gyro.userAcceleration); //Aceleración del dispositivo
		//Debug.Log("Gravedad: "+Input.gyro.gravity); //Gravedad  del dispositivo
	}

}
