using UnityEngine;
using System.Collections;

public class SituarAvatar : MonoBehaviour {
	public GameObject AvatarEquipo;
	public GameObject canvas;
	// Use this for initialization
	void Start () {

			AvatarEquipo = GameObject.FindGameObjectWithTag("AvatarI");

		if (AvatarEquipo!=null) {
			AvatarEquipo.transform.SetParent (canvas.transform);
			AvatarEquipo.transform.position = new Vector2 (75,150);
		}
	}

}
