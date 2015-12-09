using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CargarAudios : MonoBehaviour {

	public RectTransform rectPanel;
	public Text deacticvated;
	public Image panel;
	public Text texto;
	public Scrollbar barra;
	public AudioClip[] clips;
	private AudioClip clip;
	private string ruta;
	private int audios;
	public Text[] textos;
	public int bandera;

	// Use this for initialization
	void Start () {
		audios = 0;
		ruta = "audio";
		//clips = (AudioClip[]) Resources.LoadAll("audios");
		clips = Resources.LoadAll<AudioClip> (ruta);

		Rect rec = new Rect (0, 0, 100, 20);
		Vector2 vec = new Vector2 (0.5f, 0.5f);
		//Debug.Log ("Audios" + clips.Length);
		//asigna imagenes al objeto
		if(bandera == 0){
			texto.text = clips [0].name;
			textos = new Text[clips.Length];
			//bucle para instancia iamgenes.
			float hig;
			hig = deacticvated.rectTransform.sizeDelta.y;
			Debug.Log (hig);
			for(int x=0; x<clips.Length; x++)
			{
				
				rectPanel.sizeDelta = new Vector2 (rectPanel.sizeDelta.x , rectPanel.sizeDelta.y + hig + hig * 0.020f);
				Debug.Log (rectPanel.sizeDelta.x);
				Debug.Log (rectPanel.sizeDelta.y);
				//rectPanel.sizeDelta = new Vector2 (rectPanel.sizeDelta.x + (thumb.GetComponent<RectTransform> ().sizeDelta.x + (thumb.GetComponent<RectTransform> ().sizeDelta.x * 0.20f)), rectPanel.sizeDelta.y);
				//Debug.Log(rectPanel.sizeDelta);
			}
			for (int x=1; x<textos.Length; x++) {
				textos [x] = Instantiate (texto);
				textos [x].GetComponent<AudiAReproducir>().x = x;
				
				//imagenesCarrete++;
				rec = new Rect (0, 0, textos[x].rectTransform.sizeDelta.x, textos[x].rectTransform.sizeDelta.y);
				textos [x].text = clips [x].name;
				//textos [x].transform.position = new Vector2 (texto.transform.position.x + ((texto.GetComponent<RectTransform> ().sizeDelta.x , texto.transform.position.y + (texto.GetComponent<RectTransform> ().sizeDelta.y * 0.20f)) * x));
				textos [x].transform.SetParent (panel.transform);
				textos [x].gameObject.GetComponent<RectTransform> ().localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				//images[x].GetComponent<ImagePanelViewer>().i = x;
				
			}
			//imagenesCarrete++;
			StartCoroutine(Espera(0.01F));
		}

	}
	IEnumerator Espera(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		barra.value = 0;
	}
	

}
