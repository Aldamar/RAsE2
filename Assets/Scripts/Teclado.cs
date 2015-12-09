using UnityEngine;
using System.Collections;

public class Teclado : MonoBehaviour {
	public int mostrar=0;
	public void teclado(){
		System.Diagnostics.Process.Start ("osk");
		/*
		if (mostrar == 0) {
			System.Diagnostics.Process.Start ("osk");
			mostrar = 1;
		} else {
			var myProcess = new System.Diagnostics.Process();
			myProcess.StartInfo.FileName = "tskill";
			myProcess.StartInfo.Arguments = "osk";
			myProcess.Start();
			mostrar = 0;
		}
		*/
	}
}
