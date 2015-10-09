using UnityEngine;
using System.Collections;
using System;
public class Gestos : MonoBehaviour 
{
	float CoorInicial, CoorFinal, diferenciaX, diferenciaY, CoorInicial1, CoorFinal1, diferenciaX1, diferenciaY1;
	float tmpxF, tmpyF, tmpxI, tmpyI, tmpxF1, tmpyF1, tmpxI1, tmpyI1;
	int[] Sector = new int[8];
	public GameObject objeto;
	//public Text movimiento, XI, YI, XF, YF;
	// Update is called once per frame
	void Update () 
	{
		for(int i = 1; i <= 8; i++)
		{
			Sector[i]=0;
		}
		if (Input.touchSupported == true) 
		{//Validacion del soprte de touch
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			{//Obtencion de la posicion del toque inicial
				tmpxI = Input.GetTouch (0).position.x;
				tmpyI = Input.GetTouch (0).position.y;
			}
			if (Input.GetTouch (0).phase == TouchPhase.Moved) 
			{//Si se mueve el dedo obtener la posicion actual
				tmpxF = Input.GetTouch (0).position.x;
				tmpyF = Input.GetTouch (0).position.y;
				
				if(tmpxI>tmpxF){//Revisa diferencias entre las posiciones inicales y finales para calcular la diferenica siempre en numeros positivos
					diferenciaX = tmpxI - tmpxF;
				}else{
					diferenciaX = tmpxF - tmpxI;
				}
				if(tmpyI>tmpyF){
					diferenciaY = tmpyI - tmpyF;
				}else{
					diferenciaY = tmpyF - tmpyI;
				}
				
				if (Input.GetTouch (0).phase == TouchPhase.Ended) 
				{//Validacion de la finalizacion del toque
					if (diferenciaX > diferenciaY) 
					{//revisa diferencia
						//Debug.Log ("X mayor");
						CoorInicial = tmpxI;
						CoorFinal = tmpxF;

						
						if (CoorInicial > CoorFinal  && diferenciaY < 50) 
						{
							//Debug.Log ("Movimiento a la izquierda");
						} 
						if (CoorInicial > CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
							}
							if(tmpyF < tmpyI)
							{
							}
						}
						
						if (CoorInicial < CoorFinal  && diferenciaY < 50)
						{
							//Debug.Log ("Movimiento a la derecha");
						}
						if (CoorInicial < CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
							}
							if(tmpyF < tmpyI)
							{
							}
						}
					} 
					else 
					{
						//Debug.Log ("Y mayor");
						CoorInicial = tmpyI;
						CoorFinal = tmpyF;

						
						if (CoorInicial > CoorFinal && diferenciaX < 50) 
						{
							//Debug.Log ("Movimiento hacia abajo");
						}
						if (CoorInicial > CoorFinal  && diferenciaX > 50) 
						{
							if(tmpxF > tmpxI)
							{
							}
							if(tmpxF < tmpxI)
							{
							}
						}
						
						if (CoorInicial < CoorFinal  && diferenciaX < 50)
						{
							//Debug.Log ("Movimiento hacia arriba");
						}
						if (CoorInicial > CoorFinal  && diferenciaX > 50) 
						{
							if(tmpxF > tmpxI)
							{
							}
							if(tmpxF < tmpxI)
							{
							}
						}
					}
				}
			}
		} 
		else //con el mouse
		{
			if (Input.GetMouseButtonDown(0)==true)
			{
				tmpxI = Input.mousePosition.x;
				tmpyI = Input.mousePosition.y;
				//Debug.Log(tmpxI+ " " + tmpyI);
			}
			if(Input.mousePosition.x != tmpxI && Input.mousePosition.y != tmpyI)
			{
				tmpxF = Input.mousePosition.x;
				tmpyF = Input.mousePosition.y;
				
				if(tmpxI>tmpxF)
				{
					diferenciaX = tmpxI - tmpxF;
				}
				else
				{
					diferenciaX = tmpxF - tmpxI;
				}
				
				if(tmpyI>tmpyF)
				{
					diferenciaY = tmpyI - tmpyF;
				}
				else
				{
					diferenciaY = tmpyF - tmpyI;
				}
				
				if(Input.GetMouseButtonUp(0)==true)
				{
					if(diferenciaX > diferenciaY)
					{
						//Debug.Log("X mayor");
						CoorInicial = tmpxI;
						CoorFinal = tmpxF;

						
						if(CoorInicial > CoorFinal && diferenciaY < 50)
						{ 
							//Debug.Log("Movimiento a la izquierda");
						}
						if (CoorInicial > CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
							}
							if(tmpyF < tmpyI)
							{
							}
						}
						if(CoorInicial < CoorFinal && diferenciaY < 50){
							//Debug.Log("Movimiento a la derecha");
							
						}
						if (CoorInicial < CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
							}
							if(tmpyF < tmpyI)
							{
							}
						}
					}
					else
					{
						//Debug.Log("Y mayor");
						CoorInicial = tmpyI;
						CoorFinal = tmpyF;
						
						if(CoorInicial > CoorFinal)
						{
							if (diferenciaX > 50) 
							{
								if(tmpxF > tmpxI)
								{
								}
								if(tmpxF < tmpxI)
								{
								}
							}
							if(diferenciaX < 50){
							}
							//Debug.Log("Movimiento hacia abajo");
						}
						
						if(CoorInicial < CoorFinal )
						{
							
							if (diferenciaX > 50) 
							{
								if(tmpxF > tmpxI)
								{
								}
								if(tmpxF < tmpxI)
								{
								}
							}
							if(diferenciaX < 50)
							{
							}
							//Debug.Log("Movimiento hacia arriba");
						}
					}
				}
			}
		}
	}
	//-----------------------------------------------------------------
}
