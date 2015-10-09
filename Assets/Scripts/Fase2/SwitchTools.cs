using UnityEngine;
using System.Collections;

public class SwitchTools : MonoBehaviour {
	private Tools myTools;
	// Use this for initialization
	void Start () {
		myTools = GetComponent<Tools> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			myTools.enabled = true;
		}
	}
}
