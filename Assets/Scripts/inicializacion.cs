using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class inicializacion : MonoBehaviour {
	public Image imageI;
	public Image imageD;
	
	public GameObject imagICorrecta;
	public GameObject imagDcorrecta;
	
	public GameObject imagINOCorrecta;
	public GameObject imagDNOcorrecta;
	
	public Sprite[] panelIzq;
	public Sprite[] panelDer;
	
	public int contador = 0;
	
	public GameObject objetoGuarda;
	public GuardarDatos guardaValores;
	
	public GameObject final;
	// Use this for initialization
	void Start () {
		
		
		panelIzq = Resources.LoadAll<Sprite> ("Fase5/normal");
		panelDer = Resources.LoadAll<Sprite> ("Fase5/ImagenesSurr");

		if (panelDer.Length>0) {
			imageI.sprite = panelIzq [0];
			imageD.sprite = panelDer [0];
			imageI.tag="normal";
			imageD.tag="surrealista";
		}
		guardaValores = objetoGuarda.GetComponent<GuardarDatos> ();
		
	}
	
	public void OnButtonDown(int lado){
		
		//	Debug.Log (lado);
		if (lado ==0) {
			if (imageI.tag=="surrealista") {
				imagICorrecta.SetActive(true);
				StartCoroutine(Cambia(1.25F));
				guardaValores.texto += "Presiona: " + (contador+1) + imageI.tag + "\n";
			} else {
				imagINOCorrecta.SetActive(true);
				guardaValores.texto += "Presiona: " + (contador+1) + imageI.tag + "\n";
			}
			
		}
		if (lado ==1) {
			if (imageD.tag=="surrealista") {
				imagDcorrecta.SetActive(true);
				StartCoroutine(Cambia(1.25F));
				guardaValores.texto += "Presiona: " +  (contador+1) + imageD.tag + "\n";
			} else {
				imagDNOcorrecta.SetActive(true);
				guardaValores.texto += "Presiona: " +  (contador+1) + imageD.tag + "\n";
			}
			
		}
		
		
	}
	
	IEnumerator Cambia(float waitTime) {
		int aleatorio;
		aleatorio =  Random.Range (1,6) ;
		//Debug.Log(aleatorio);
		
		
		yield return new WaitForSeconds(waitTime);
		
		
		if (contador != panelIzq.Length - 1) {	
			if (aleatorio % 2 == 0) {
				imageI.sprite = panelIzq [contador + 1];
				imageD.sprite = panelDer [contador + 1];
				imageD.tag = "surrealista";
				imageI.tag = "normal";
				if (contador < panelDer.Length)
					contador++;
			} else {
				
				imageI.sprite = panelDer [contador + 1];
				imageI.tag = "surrealista";
				imageD.tag = "normal";
				imageD.sprite = panelIzq [contador + 1];
				if (contador < panelDer.Length)
					contador++;
			}
		} else {
			
			Debug.Log ("Emtra guarda");
			guardaValores.GuardaValores();
			final.SetActive(true);
		}
		
		imagICorrecta.SetActive (false);
		imagDcorrecta.SetActive (false);
		imagINOCorrecta.SetActive (false);
		imagDNOcorrecta.SetActive (false);
		
		
		
		
	}
	
	public void EvaluacionFase6() {
		PlayerPrefs.SetInt ("FaseFinal", 6);
		Application.LoadLevel ("iniciar");
	}
	
}
