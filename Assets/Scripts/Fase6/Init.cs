using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Init : MonoBehaviour {
	public int usuario;
	public string[] nombre = new string[6];

	// Use this for initialization
	void Start () {
		nombre [0] = "uno";
		nombre [1] = "dos";
		nombre [2] = "tres";
		nombre [3] = "cuatro2";
		nombre [4] = "cinco";
		nombre [5] = "seis";
		nombre [6] = "siente";
		nombre [7] = "ocho";
		nombre [9] = "ocho";
		usuario = 0;
		//Debug.Log(PlayerPrefs.GetInt("IntegrantesTotal"));
		for (int i = 1; i < PlayerPrefs.GetInt("IntegrantesTotal");i++) {
			if (PlayerPrefs.GetString ("Integrante"+i) != null ||PlayerPrefs.GetString ("Integrante"+i)!="")
				nombre [i] =PlayerPrefs.GetString ("Integrante"+i);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
