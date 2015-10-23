using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comentarios : MonoBehaviour {

	public GameObject comentas;
	public int bandera;

	void Start()
	{
		bandera = 0;
	}
	public void coments(){
		if(bandera == 0)
		{
			comentas.SetActive (true);
			bandera = 1;
		}else{
			comentas.SetActive (false);
			bandera = 0;
		}
	}
}
