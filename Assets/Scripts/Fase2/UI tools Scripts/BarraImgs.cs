using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BarraImgs : MonoBehaviour 
{
	public int Barra;
	public Button Animales, Objetos, Personas;
	public GameObject Anim, Obj, Per, scroll;
	public void OnButtondown()
	{
		switch (Barra) 
		{
		case 1:
			scroll.GetComponent<ScrollRect>().content = Anim.GetComponent<RectTransform>();
			Objetos.interactable = true;
			Personas.interactable = true;
			Anim.SetActive(true);
			Obj.SetActive(false);
			Per.SetActive(false);
			Animales.interactable = false;
			break;

		case 2:
			scroll.GetComponent<ScrollRect>().content = Obj.GetComponent<RectTransform>();
			Animales.interactable = true;
			Personas.interactable = true;
			Obj.SetActive(true);
			Anim.SetActive(false);
			Per.SetActive(false);
			Objetos.interactable = false;
			break;
		
		case 3:
			scroll.GetComponent<ScrollRect>().content = Per.GetComponent<RectTransform>();
			Objetos.interactable = true;
			Animales.interactable = true;
			Per.SetActive(true);
			Anim.SetActive(false);
			Obj.SetActive(false);
			Personas.interactable = false;
			break;
		
		default:
			break;
		}
	}
}
