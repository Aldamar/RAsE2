using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	public static Vector3 startPosition;
	public static Transform startParent;
	public  GameObject AreaDeTrabajo, AreaFondo, panel;
	GameObject tmp;
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		if(startParent.tag != "Area De Trabajo")
		{
			tmp = Instantiate(DragHandeler.itemBeingDragged);
			tmp.GetComponent<CanvasGroup>().blocksRaycasts = true;
			tmp.transform.position = DragHandeler.startPosition;
			tmp.transform.SetParent(DragHandeler.startParent);
			tmp.transform.localScale = new Vector3(1,1,1);
			tmp.GetComponent<CanvasGroup> ().blocksRaycasts = false;
			
			itemBeingDragged = tmp;

		}


	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if (Input.touchSupported == true) 
		{
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 tch = Input.GetTouch(0).deltaPosition;
				itemBeingDragged.transform.position = new Vector2 (tch.x,tch.y);
				itemBeingDragged.GetComponent<Image>().type = Image.Type.Filled;
			}
		} 
		else 
		{
			itemBeingDragged.transform.position = Input.mousePosition;
		}
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{

		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (startParent.tag != "Area De Trabajo") 
		{
			tmp.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
		if(itemBeingDragged.transform.parent == panel)
		{
			itemBeingDragged.transform.position = startPosition;
		}
		itemBeingDragged = null;
	}

	#endregion
}
