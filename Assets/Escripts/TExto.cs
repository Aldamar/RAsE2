using UnityEngine;
using System.Collections;

public class TExto : MonoBehaviour {
	public GameObject panel;
	int x;
	void Start()
	{
		x = 0;
	}
	public void onButtonDown(){
		if (x == 0) {
			panel.SetActive (true);
			x = 1;
		} else {
			panel.SetActive(false);
			x = 0;
		}
	}
}
