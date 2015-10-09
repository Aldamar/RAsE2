using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TresD : MonoBehaviour {
	public GameObject tresD, dosD;
	// Use this for initialization
	public void OnButtonDown(){
		tresD.SetActive (true);
		dosD.SetActive (false);
	}
}
