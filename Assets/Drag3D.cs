using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drag3D : MonoBehaviour/*,  IBeginDragHandler, IDragHandler, IEndDragHandler */{


	private bool dragging = false;
	private float distance;
	
	
	void OnMouseEnter()
	{
		//renderer.material.color = mouseOverColor;
	}
	
	void OnMouseExit()
	{
		//renderer.material.color = originalColor;
	}
	
	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
	
	void OnMouseUp()
	{
		dragging = false;
	}
	
	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
//	public static GameObject itemBeingDragged;
//	public static Vector3 startPosition;
//	public static Transform startParent;
//
//	#region IBeginDragHandler implementation
//
//	public void OnBeginDrag (PointerEventData eventData)
//	{
//		itemBeingDragged = gameObject;
//		startPosition = transform.position;
//		startParent = transform.parent;
//		GetComponent<CanvasGroup> ().blocksRaycasts = false;
//	}
//
//	#endregion
//
//	#region IDragHandler implementation
//
//	public void OnDrag (PointerEventData eventData)
//	{
//		itemBeingDragged.transform.position = Input.mousePosition;
//	}
//
//	#endregion
//
//	#region IEndDragHandler implementation
//
//	public void OnEndDrag (PointerEventData eventData)
//	{
//		itemBeingDragged = null;
//		GetComponent<CanvasGroup> ().blocksRaycasts = true;
//		itemBeingDragged.transform.position = startPosition;
//
//	}
//
//	#endregion

	
}
