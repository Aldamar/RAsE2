using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour {
	public GameObject camara;
	Gyroscope Giroscopio;
	// Use this for initialization


	void Start () {
		Input.gyro.enabled = true; //Habilitar el giroscopio
	}
	
	// Update is called once per frame
	void Update () {

		camara.transform.Rotate (Vector3.up,(Input.gyro.rotationRate.x*Input.gyro.userAcceleration.x));

		camara.transform.Rotate (Vector3.back,(Input.gyro.rotationRate.y*Input.gyro.userAcceleration.y));
		camara.transform.Rotate (Vector3.left,(Input.gyro.rotationRate.z*Input.gyro.userAcceleration.z));
	}

}
