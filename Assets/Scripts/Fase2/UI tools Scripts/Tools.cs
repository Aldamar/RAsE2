using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class Tools : MonoBehaviour
{
	public GameObject panelBotonesOperaciones;
	public GameObject panelEditar;
	public GameObject panelPadre;
	public botones opcionPanel;
	public Image[] imagenAEditar;

	public GameObject tmp;
	// Use this for initialization
	EventTrigger eventTrigger = null;
	
	//[SerializeField]
	//private Text textField = null;
	
	//[SerializeField]
	//private Toggle toggle = null;
	
	// Use this for initialization
	void Start()
	{

		panelBotonesOperaciones = GameObject.Find("PanelBotones");
		panelEditar = GameObject.Find("Area de Trabajo");
		panelPadre = GameObject.Find("Canvas");
		tmp = GameObject.Find("Grupo");

		opcionPanel = panelBotonesOperaciones.GetComponent<botones>();

		imagenAEditar = transform.GetComponentsInParent<Image>(); //El indice 1 es el que editara
		
		eventTrigger = gameObject.GetComponent<EventTrigger>();
		
		AddEventTrigger(OnPointerClick, EventTriggerType.PointerClick);
		//	AddEventTrigger(OnPointerEnter, EventTriggerType.PointerEnter, toggle);
		AddEventTrigger(OnPointerEnter, EventTriggerType.PointerEnter);
		AddEventTrigger(OnPointerExit, EventTriggerType.PointerExit);
		AddEventTrigger(OnPointerDown, EventTriggerType.PointerDown);
		AddEventTrigger(OnPointerUp, EventTriggerType.PointerUp);
		AddEventTrigger(OnDrag, EventTriggerType.Drag);
		AddEventTrigger(OnDrop, EventTriggerType.Drop);
		AddEventTrigger(OnScroll, EventTriggerType.Scroll);
		
	}







	#region TriggerEventsSetup



	// Use listener with no parameters
	private void AddEventTrigger(UnityAction action, EventTriggerType triggerType)
	{
		// Create a nee TriggerEvent and add a listener
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action()); // ignore event data
		
		// Create and initialise EventTrigger.Entry using the created TriggerEvent
		EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
		
		// Add the EventTrigger.Entry to delegates list on the EventTrigger
		eventTrigger.triggers.Add(entry);
	}
	
	// Use listener that uses the BaseEventData passed to the Trigger
	private void AddEventTrigger(UnityAction<BaseEventData> action, EventTriggerType triggerType)
	{
		// Create a nee TriggerEvent and add a listener
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action(eventData)); // capture and pass the event data to the listener
		
		// Create and initialise EventTrigger.Entry using the created TriggerEvent
		EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
		
		// Add the EventTrigger.Entry to delegates list on the EventTrigger
		eventTrigger.triggers.Add(entry);
	}
	
	// Use listener that uses additional argument
	private void AddEventTrigger(UnityAction<Toggle> action, EventTriggerType triggerType, Toggle toggle)
	{
		// Create a nee TriggerEvent and add a listener
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action(toggle)); // pass additonal argument to the listener
		
		// Create and initialise EventTrigger.Entry using the created TriggerEvent
		EventTrigger.Entry entry = new EventTrigger.Entry() { callback = trigger, eventID = triggerType };
		
		// Add the EventTrigger.Entry to delegates list on the EventTrigger
		eventTrigger.triggers.Add(entry);
	}
	
	#endregion
	
	
	#region Callbacks
	/*public Image clon;

	public void  Prueba_corte(){
		
		if (Input.mousePresent) {
			clon = Instantiate (imagenAEditar [0]);
			Destroy (imagenAEditar [0]);


			clon.type = Image.Type.Filled;


		}
	}*/


	private void OnPointerClick(BaseEventData data)
	{
		//textField.text = "OnPointerClick " + data.selectedObject;
		
		// es frente
		if (opcionPanel.opcion == 1) {  
			imagenAEditar[0].gameObject.transform.SetParent(panelPadre.transform);
			imagenAEditar[0].gameObject.transform.SetParent(panelEditar.transform);
		}
		//cortar
		if (opcionPanel.opcion == 8 || opcionPanel.opcion == 7 || opcionPanel.opcion == 6) {
			imagenAEditar[0].type = Image.Type.Filled;

			//imagenAEditar[0].fillAmount -=0.05f;

			//clon.fillAmount -=0.05f;



		}
		//rotar
		if (opcionPanel.opcion == 3) {
			imagenAEditar[0].rectTransform.Rotate (Vector3.back);
		}
		if (opcionPanel.opcion == 4) {
			imagenAEditar[0].transform.SetParent(tmp.transform);
		}
		if (opcionPanel.opcion == 5) {
			Vector3 theScale = imagenAEditar[0].transform.localScale;
			theScale.x *= -1;
			imagenAEditar[0].transform.localScale = theScale;

			/*
			if(imagenAEditar[0].transform.rotation.y == 180)
			{
				imagenAEditar[0].transform.eulerAngles = new Vector3(0f,0f,0f);
			}else
			{
				imagenAEditar[0].transform.eulerAngles = new Vector3(0f,180f,0f);
			}*/
		}
		if (opcionPanel.opcion == 6) {

			imagenAEditar[0].fillMethod = Image.FillMethod.Horizontal;
			imagenAEditar[0].fillAmount -=0.05f;


		}
		if (opcionPanel.opcion == 7) {

			imagenAEditar[0].fillMethod = Image.FillMethod.Vertical;
			imagenAEditar[0].fillAmount -=0.05f;
			
		}
		if (opcionPanel.opcion == 8) {

			imagenAEditar[0].fillMethod = Image.FillMethod.Radial360;
			imagenAEditar[0].fillAmount -=0.05f;
			
		}

		//Debug.Log("OnPointerClick ");
	}

	private void OnPointerEnter()
	{
		//Debug.Log( "OnPointerEnter");
	}
	private void OnPointerExit()
	{
		//Debug.Log("OnPointerExit");
	}
	
	private void OnPointerDown()
	{
		//Debug.Log("Entra down");
		
	}
	
	private void OnPointerUp()
	{
		
		//Debug.Log( "OnPointerUp");
	} 
	
	private void OnDrag()
	{
		//Debug.Log("OnDrag");
	}
	
	private void OnDrop()
	{
		//Debug.Log("OnDrop");
	}
	
	private void OnScroll()
	{
		//Debug.Log("OnScroll");
	} 
	#endregion
}