using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.IO;
//using System.Diagnostics;

public class Carga : MonoBehaviour {

	public Texture2D[] individual, grupo;
	public Image pindividual, pgrupo, prefab;
	public Image[] aindividual, agrupo;
	public int[] ifindividual, ioindividual, ifgrupo, iogrupo;

	public Canvas lienzo;
	public int usuario;
	public Text nombre;
	public Text fin;
	public GameObject panelEval;
	public GameObject panelFaltanDatos;

	public WWW www;

	private string url;
	private int z;
	IEnumerator Start() {
		usuario = lienzo.GetComponent<Init> ().usuario;
		//nombre.text = lienzo.GetComponent<Init>().nombre[usuario];
		//nombre.text = "EQUIPO: " + panelEval.GetComponent<Evaluador>().nombreEquipo;
		//individual = Resources.LoadAll<Texture2D> ("Fase6/individual");
		//grupo = Resources.LoadAll<Texture2D> ("Fase6/grupo");

		//---Carga externa--------
		//string url = "file://C:/Users/alexa_000/Desktop/Individual/(207).jpg";
		//string url = "file://"+Application.persistentDataPath+"/../../../../Desktop/individuales/imagen"+1+".jpg";

		DirectoryInfo dir = new DirectoryInfo (Application.persistentDataPath + "/Resources/Fase2/individual/");
		FileInfo[] info = dir.GetFiles ("*.*");
		int h = 0;
		foreach (FileInfo f in info) {
			h++;
		}
		if (h != 0) {
			url = "file://" + Application.persistentDataPath + "/Resources/Fase2/individual/imagen" + 1 + ".jpg";
			www = new WWW (url);
			yield return www;

			int z = 0;
			while ((int)www.texture.width != 8) {
				//url = "file://"+Application.persistentDataPath+"/../../../../Desktop/individuales/imagen"+(z+1)+".jpg";
				url = "file://" + Application.persistentDataPath + "/Resources/Fase2/individual/imagen" + (z + 1) + ".jpg";
				www = new WWW (url);
				if (www.texture.width != 8)
					yield return www;
				else 
					break;
				//if ((int)www.texture.width == 8) break;
				z++;
			}
			individual = new Texture2D[z];

			z = 0;
			while (z<individual.Length){
				z++;
				//url = "file://"+Application.persistentDataPath+"/../../../../Desktop/individuales/imagen"+z+".jpg";
				url = "file://"+Application.persistentDataPath+"/Resources/Fase2/individual/imagen"+z+".jpg";
				www = new WWW(url);
				yield return www;
				individual [z-1] = www.texture;
			}
		}


		dir = new DirectoryInfo (Application.persistentDataPath + "/Resources/Fase2/grupal/");
		info = dir.GetFiles ("*.*");
		h = 0;
		foreach (FileInfo f in info) 
		{
			h++;
		}	
		 if (h != 0) {
			//url = "file://"+Application.persistentDataPath+"/../../../../Desktop/grupo/imagen"+1+".jpg";
			url = "file://"+Application.persistentDataPath+"/Resources/Fase2/grupal/imagen"+1+".jpg";
			www = new WWW(url);
			yield return www;
			 z = 0;
			while ((int)www.texture.width != 8){
				//url = "file://"+Application.persistentDataPath+"/../../../../Desktop/grupo/imagen"+(z+1)+".jpg";
				url = "file://"+Application.persistentDataPath+"/Resources/Fase2/grupal/imagen"+(z+1)+".jpg";
				www = new WWW(url);
				if (www.texture.width!=8)
					yield return www;
				else 
					break;
				
				//	yield return www;
				//	if ((int)www.texture.width == 8) break;
				z++;
				grupo = new Texture2D[z];

				z = 0;
				while (z<grupo.Length){
					z++;
					//url = "file://"+Application.persistentDataPath+"/../../../../Desktop/grupo/imagen"+z+".jpg";
					url = "file://"+Application.persistentDataPath+"/Resources/Fase2/grupal/imagen"+z+".jpg";
					www = new WWW(url);
					yield return www;
					grupo [z-1] = www.texture;
			}
		}
	}
		//------------------------

		ifindividual = new int[individual.Length];
		ioindividual = new int[individual.Length];
		ifgrupo = new int[grupo.Length];
		iogrupo = new int[grupo.Length];

		Rect r;
		Vector2 v = new Vector2 (0.5f,0.5f);

		aindividual = new Image[individual.Length];
		for (int x=0; x<individual.Length; x++) {
			aindividual[x] = Instantiate(prefab);
			r = new Rect (0,0,individual[x].width,individual[x].height);
			aindividual[x].GetComponentsInChildren<Image>()[1].sprite = Sprite.Create(individual[x],r,v);
			aindividual[x].transform.SetParent(pindividual.transform);

			ifindividual[x] = -1;
			ioindividual[x] = -1;

			aindividual[x].GetComponentsInChildren<Image>()[1].GetComponent<Modal>().tipo = 0;
			aindividual[x].GetComponentsInChildren<Image>()[1].GetComponent<Modal>().indice = x;
		}

		agrupo = new Image[grupo.Length];
		for (int x=0; x<grupo.Length; x++) {
			agrupo[x] = Instantiate(prefab);
			r = new Rect (0,0,grupo[x].width,grupo[x].height);
			agrupo[x].GetComponentsInChildren<Image>()[1].sprite = Sprite.Create(grupo[x],r,v);
			agrupo[x].transform.SetParent(pgrupo.transform);

			ifgrupo[x] = -1;
			iogrupo[x] = -1;

			agrupo[x].GetComponentsInChildren<Image>()[1].GetComponent<Modal>().tipo = 1;
			agrupo[x].GetComponentsInChildren<Image>()[1].GetComponent<Modal>().indice = x;
		}
	}

	/*
	void Update(){
		if (usuario == lienzo.GetComponent<Init>().nombre.Length-1){
			fin.text = "Finalizar";
		}
	}
*/
	public void cambio(){

		for (int x=0; x<individual.Length; x++) {
			ifindividual[x] = (int)aindividual [x].GetComponentsInChildren<Slider> ()[0].value;
			ioindividual[x] = (int)aindividual [x].GetComponentsInChildren<Slider> ()[1].value;
		}
		for (int x=0; x<grupo.Length; x++) {
			ifgrupo[x] = (int)agrupo [x].GetComponentsInChildren<Slider> ()[0].value;
			iogrupo[x] = (int)agrupo [x].GetComponentsInChildren<Slider> ()[1].value;
		}

	}

	public void continuar(){
		int encontro = 0;

		for (int x=0; x<individual.Length; x++) {
			if (ifindividual[x] < 1 || ioindividual[x] < 1) { encontro = 1; break; }
		}

		for (int x=0; x<grupo.Length; x++) {
			if (ifgrupo[x] < 1 || iogrupo[x] < 1) { encontro = 1; break; }
		}

		if (encontro == 0) {
			panelEval.SetActive(true);
			panelEval.GetComponent<Evaluador>().GuardaEvaluacion();
			panelEval.GetComponent<Evaluador>().usuario.text="";

			//if (usuario < lienzo.GetComponent<Init>().nombre.Length-1){
			//	usuario++;
			//	nombre.text = lienzo.GetComponent<Init>().nombre[usuario];
				for (int x=0;x<individual.Length;x++){
					aindividual [x].GetComponentsInChildren<Slider> ()[0].value = 0;
					aindividual [x].GetComponentsInChildren<Slider> ()[1].value = 0;
				}
				for (int x=0;x<grupo.Length;x++){
					agrupo [x].GetComponentsInChildren<Slider> ()[0].value = 0;
					agrupo [x].GetComponentsInChildren<Slider> ()[1].value = 0;
				}
			//}else{ 
			//	Debug.Log ("Fase terminada");
			//}
			Debug.Log ("Finalizado");
			/*panelEval.SetActive(true);
			panelEval.GetComponent<Evaluador>().GuardaEvaluacion();
			panelEval.GetComponent<Evaluador>().usuario.text="";*/
			Modal.gameObject.SetActive (false);
			Application.LoadLevel("Fase6");
		} else {
			panelFaltanDatos.SetActive(true);
			Debug.Log ("Aun no has terminado de evaluar");
		}
	}

	public int mostrar=0;
	/*
	public void teclado(){
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
	}
	*/
	public Image Modal;


	public int tipo, indice;
	public Slider flexibilidad, originalidad;
	public Text tflex, torig;
	public void cambiomodal(){

		if (tipo == 0) {
			aindividual [indice].GetComponentsInChildren<Slider> ()[0].value = (int)flexibilidad.value;
			aindividual [indice].GetComponentsInChildren<Slider> ()[1].value = (int)originalidad.value;
			ifindividual[indice] = (int)flexibilidad.value;
			ioindividual[indice] = (int)originalidad.value;
		} else {
			agrupo [indice].GetComponentsInChildren<Slider> ()[0].value = (int)flexibilidad.value;
			agrupo [indice].GetComponentsInChildren<Slider> ()[1].value = (int)originalidad.value;
			ifgrupo[indice] = (int)flexibilidad.value;
			iogrupo[indice] = (int)originalidad.value;
		}
		tflex.text = "Flexibilidad: " + (int)flexibilidad.value;
		torig.text = "Originalidad: " + (int)originalidad.value;

	}

	public void cerrarmodal(){
		//Modal.GetComponentsInChildren<Slider> ()[0].value = (int)flexibilidad.value;
		//Modal.GetComponentsInChildren<Slider> ()[1].value = (int)originalidad.value;
		Modal.gameObject.SetActive (false);
	}
	public void OcultaFaltanDatos() {
		panelFaltanDatos.SetActive(false);
	}

	public void GuardaValores0() {
		panelEval.SetActive(true);
		panelEval.GetComponent<Evaluador>().GuardaEvaluacion();
		panelEval.GetComponent<Evaluador>().usuario.text="";
		panelFaltanDatos.SetActive(false);
		Modal.gameObject.SetActive (false);
		Application.LoadLevel("Fase6");

	}
}