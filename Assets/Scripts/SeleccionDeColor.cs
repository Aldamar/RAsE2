using UnityEngine;
using System.Collections;

public class SeleccionDeColor : MonoBehaviour {
private Texture[] texturas;

public GameObject objeto, fondo;

	void Start()
	{
		texturas = Resources.LoadAll<Texture> ("texturas");
	}

	#region colores
	//Cambia color de los objetos 3D
	public void Azul(){
		objeto.GetComponent<Renderer> ().material.color = Color.blue;
	}
	public void Verde(){
		objeto.GetComponent<Renderer> ().material.color = Color.green;
	}
	public void Negro(){
		objeto.GetComponent<Renderer> ().material.color = Color.black;
	}
	public void Blanco(){
		objeto.GetComponent<Renderer> ().material.color = Color.white;
	}
	public void Rojo(){
		objeto.GetComponent<Renderer> ().material.color = Color.red;
	}
	public void GrisC(){
		objeto.GetComponent<Renderer> ().material.color = new Color(0.7843137254901961f,0.7843137254901961f,0.7843137254901961f);
	}
	public void GrisO(){
		objeto.GetComponent<Renderer> ().material.color = Color.grey;
	}
	public void Magenta(){
		objeto.GetComponent<Renderer> ().material.color = Color.magenta;
	}
	public void Cyan(){
		objeto.GetComponent<Renderer> ().material.color = Color.cyan;
	}
	public void Amarillo(){
		objeto.GetComponent<Renderer> ().material.color = Color.yellow;
	}
	public void Naranja(){
		objeto.GetComponent<Renderer> ().material.color = new Color(1f,0.392156862745098f,0f);
	}
	public void VerdeO(){
		objeto.GetComponent<Renderer> ().material.color = new Color(0f,0.5f,0f);
	}
	public void Rosa(){
		objeto.GetComponent<Renderer> ().material.color = new Color(1f,0.5f,0.7843137254901961f);
	}
	public void Morado(){
		objeto.GetComponent<Renderer> ().material.color = new Color(0.5f,0f,1f);
	}
	public void Tinto(){
		objeto.GetComponent<Renderer> ().material.color = new Color(0.5f,0f,0f);
	}
	public void Cafe(){
		objeto.GetComponent<Renderer> ().material.color = new Color(0.392156862745098f,0.1568627450980392f,0f);
	}
	#endregion

	#region materiales
	//Seleccion de material
	public void metal(){ //nombres sujetos a cambios
		objeto.GetComponent<Renderer> ().material.mainTexture = texturas [0];	
	}
	public void madera(){
		objeto.GetComponent<Renderer> ().material.mainTexture = texturas [1];
	}

	#endregion
}
