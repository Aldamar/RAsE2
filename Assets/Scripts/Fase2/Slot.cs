using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {
	//public Image lienzo;
	public Image panel;
	
	#region IDropHandler implementation
	
	public void OnDrop (PointerEventData eventData)
	{
		if (DragHandeler.itemBeingDragged == null) {
		} else 
		if (DragHandeler.startParent != panel.transform) {
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			DragHandeler.itemBeingDragged.transform.position = Input.mousePosition;
			DragHandeler.itemBeingDragged.GetComponent<Tools>().enabled = true;
		}else {
//			GameObject tmp = Instantiate(DragHandeler.itemBeingDragged);
//			tmp.transform.localScale = new Vector3(1,1,1);
//			tmp.transform.position = DragHandeler.startPosition;
//			tmp.transform.SetParent(DragHandeler.startParent);
//			tmp.transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
			DragHandeler.itemBeingDragged.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f,0.5f);
			DragHandeler.itemBeingDragged.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f,0.5f);
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			DragHandeler.itemBeingDragged.transform.position = Input.mousePosition;
		}
		/*else{
			Destroy(DragHandeler.itemBeingDragged);*/
	}
	
	#endregion
}