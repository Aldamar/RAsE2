using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoverRotarObjeto3d : MonoBehaviour {
	public GameObject objeto, flechas, MenuRotar;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	public void MoverDerecha () {
	  if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x + 0.1f , objeto.transform.position.y, objeto.transform.position.z);
	}

	public void MoverIzquierda() {
	   if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x - 0.1f , objeto.transform.position.y, objeto.transform.position.z);
	}

	public void Subir(){
	   if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x , objeto.transform.position.y + 0.1f, objeto.transform.position.z);
	}

	public void Bajar(){
	  if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x , objeto.transform.position.y - 0.1f, objeto.transform.position.z);
	}

	public void Acercar(){
      if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x , objeto.transform.position.y, objeto.transform.position.z -0.1f);
	}
	
	public void Alejar(){
	   if (objeto!=null)
		objeto.transform.position = new Vector3 (objeto.transform.position.x , objeto.transform.position.y, objeto.transform.position.z + 0.1f);
	}

	public void Crecer(){
	  if (objeto!=null)
		objeto.transform.localScale = new Vector3 (objeto.transform.localScale.x+0.02f,objeto.transform.localScale.y+0.02f,objeto.transform.localScale.z+0.02f);
	}
	
	public void Disminuir(){
	   if (objeto!=null)
		objeto.transform.localScale = new Vector3 (objeto.transform.localScale.x-0.02f,objeto.transform.localScale.y-0.02f,objeto.transform.localScale.z-0.02f);
	}

	public void Rotar() {
		//flechas.transform.position = new Vector3(objeto.transform.position.x,objeto.transform.position.y,objeto.transform.position.z-0.5f);
	  if (objeto!=null)
		objeto.transform.Rotate(Vector3.right*50 * Time.deltaTime);
		//MenuRotar.SetActive (true);
	}

	public void Reset(){
	 if (objeto!=null)
		objeto.transform.rotation = Quaternion.identity;
	}
	public void borrar(){
	  if (objeto!=null)
		Destroy (objeto);
	}
	public void desactivarMenu(){
		//MenuRotar.SetActive (false);
	}

	public void AplicaColor(GameObject obj) {
	 if (objeto!=null)
		objeto.GetComponent<Renderer>().material.color=obj.GetComponent<Button>().targetGraphic.color;
	}
	
	void Update() {

	}
}
