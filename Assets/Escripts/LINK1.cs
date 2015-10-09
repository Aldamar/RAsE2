using UnityEngine;
using System.Collections;

public class LINK1 : MonoBehaviour {


	public void configurar ()
	{
		Application.LoadLevel("Uno");
	}

	public void iniciar()
	{
		Application.LoadLevel ("Dos");
	}

	public void volver ()
	{
		Application.LoadLevel ("Menu");
	}

	public void vuforia ()
	{
		Application.LoadLevel ("Vuforia");
	}
}
