using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Seleccion : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public Image fondo;
	public Image selectionimg;
	public static Image seleccion;

	public Canvas lienzo;

	public static int ix, iy, fx, fy;
	public static int width, height;

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
		Destroy (seleccion);
		seleccion = Instantiate (selectionimg);
		seleccion.transform.position = Input.mousePosition;
		seleccion.transform.SetParent (lienzo.transform);
		ix = (int)seleccion.transform.position.x;
		iy = (int)seleccion.transform.position.y;
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		fx = (int)Input.mousePosition.x;
		fy = (int)Input.mousePosition.y;

		width = fx>ix?fx-ix:ix-fx;
		height = fy>iy?fy-iy:iy-fy;

		RectTransform tamanio = seleccion.GetComponent<RectTransform> ();
		tamanio.sizeDelta = new Vector2 (width,height);
		int iix=0;
		int iiy=0;
		if (ix < fx) {
			iix = (int)(seleccion.rectTransform.sizeDelta.x / 2 + ix);
			iiy = (int)(seleccion.rectTransform.sizeDelta.y / 2 + iy);
		} else {
			iix = (int)(ix - seleccion.rectTransform.sizeDelta.x / 2);
			iiy = (int)(seleccion.rectTransform.sizeDelta.y / 2 + iy);
		}
		if (iy < fy) {
			iiy = (int)(seleccion.rectTransform.sizeDelta.y / 2 + iy);
		} else {
			iiy = (int)(iy - seleccion.rectTransform.sizeDelta.y / 2);
		}
		seleccion.transform.position = new Vector2 (iix,iiy);
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		//throw new System.NotImplementedException ();
	}

	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
