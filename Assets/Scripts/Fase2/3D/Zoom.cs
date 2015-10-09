using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
//using UnityEditor;
public class Zoom : MonoBehaviour 
{
	float CoorInicial, CoorFinal, diferenciaX, diferenciaY, CoorInicial1, CoorFinal1, diferenciaX1, diferenciaY1;
	float tmpxF, tmpyF, tmpxI, tmpyI, tmpxF1, tmpyF1, tmpxI1, tmpyI1;
	int[] Sector = new int[9];
	int w,h;
	//public GameObject objeto;
	
	public int zoom (Image objeto)
	{
		for(int i = 1; i <= 8; i++)
		{
			Sector[i]=0;
		}
		if (Input.touchSupported == true) 
		{//Validacion del soprte de touch
			if(Input.multiTouchEnabled == true && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(1).phase == TouchPhase.Began)
			{//Validacion de multitouch y el movimineto de dos o más dedos
				tmpxI = Input.GetTouch (0).position.x;
				tmpyI = Input.GetTouch (0).position.y;
				tmpxI1 = Input.GetTouch (1).position.x;
				tmpyI1 = Input.GetTouch (1).position.y;
				if(Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
				{
					tmpxF = Input.GetTouch (0).position.x;
					tmpyF = Input.GetTouch (0).position.y;
					tmpxF1 = Input.GetTouch (1).position.x;
					tmpyF1 = Input.GetTouch (1).position.y;
					if(tmpxI>tmpxF)
					{//Revisa diferencias entre las posiciones inicales y finales para calcular la diferenica siempre en numeros positivos
						diferenciaX = tmpxI - tmpxF;
						diferenciaX1 = tmpxI1 - tmpxF1;
					}else{
						diferenciaX = tmpxF - tmpxI;
						diferenciaX1 = tmpxF1 - tmpxI1;
					}
						if(tmpyI>tmpyF){
						diferenciaY = tmpyI - tmpyF;
						diferenciaY1 = tmpyI1 - tmpyF1;
					}else{
						diferenciaY = tmpyF - tmpyI;
						diferenciaY1 = tmpyF1 - tmpyI1;
					}
					//Empieza rescalamiento, tiene que se en tiempo real. Es decir en la fase de movimiento y no en la final
						if(diferenciaX > diferenciaY)
						{
						//Debug.Log("X mayor");
						CoorInicial = tmpxI;
						CoorFinal = tmpxF;
							
						if(CoorInicial > CoorFinal && diferenciaY < 50)
						{ 
							Sector[6] = 1;
							//Debug.Log("Movimiento a la izquierda");
						}
						if (CoorInicial > CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
								Sector[2] = 1;
							}
							if(tmpyF < tmpyI)
							{
								Sector[3] = 1;
							}
						}
						if(CoorInicial < CoorFinal && diferenciaY < 50){
							Sector[8] = 1;
							//Debug.Log("Movimiento a la derecha");
						}
						if (CoorInicial < CoorFinal  && diferenciaY > 50) 
						{
							if(tmpyF > tmpyI)
							{
								Sector[1] = 1;
							}
							if(tmpyF < tmpyI)
							{
								Sector[4] = 1;
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
									Sector[4] = 1;
								}
								if(tmpxF < tmpxI)
								{
									Sector[3] = 1;
								}
							}
							if(diferenciaX < 50){
								Sector[7] = 1;
							}
							//Debug.Log("Movimiento hacia abajo");
						}
						
						if(CoorInicial < CoorFinal ){
							
							if (diferenciaX > 50) 
							{
								if(tmpxF > tmpxI)
									{
									Sector[1] = 1;
								}
								if(tmpxF < tmpxI)
								{
									Sector[2] = 1;
								}
							}
							if(diferenciaX < 50)
							{
								Sector[5] = 1;
							}
						}
					}
						if(diferenciaX1 > diferenciaY1)
					{
						//Debug.Log("X mayor");
						CoorInicial1 = tmpxI1;
						CoorFinal1 = tmpxF1;
							
						if(CoorInicial1 > CoorFinal1 && diferenciaY1 < 50)
						{ 
							Sector[6] = 1;
							if(Sector[8]==1)
							{
								Debug.Log("Scale a lo ancho");
								objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y);
								w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
								h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								//objeto.transform.localScale = new Vector3(1+0.1f,1,1);
							}
							//Debug.Log("Movimiento a la izquierda");
						}
						if (CoorInicial1 > CoorFinal1  && diferenciaY1 > 50) 
						{
							if(tmpyF1 > tmpyI1)
							{
								Sector[2] = 1;
								if(Sector[4]==1)
								{
									Debug.Log("Scale total");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
									//objeto.transform.localScale = new Vector3(1+0.1f,1+0.1f,1+0.1f);
								}
							}
							if(tmpyF1 < tmpyI1)
							{
								Sector[3] = 1;
								if(Sector[1]==1)
								{
									Debug.Log("Scale total");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								}
							}
						}
						if(CoorInicial1 < CoorFinal1 && diferenciaY1 < 50){
							Sector[8] = 1;
							if(Sector[6]==1)
							{
								Debug.Log("Scale a lo ancho");
								objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y);
								w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
								h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
							}
							//Debug.Log("Movimiento a la derecha");
						}
						if (CoorInicial1 < CoorFinal1  && diferenciaY1 > 50) 
						{
							if(tmpyF1 > tmpyI1)
							{
								Sector[1] = 1;
								if(Sector[3]==1)
								{
									Debug.Log("Scale total");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								}
							}
							if(tmpyF1 < tmpyI1)
							{
								Sector[4] = 1;
								if(Sector[2]==1)
								{
									Debug.Log("Scale total");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								}
							}
						}
					}
					else
					{
						//Debug.Log("Y mayor");
						CoorInicial1 = tmpyI1;
						CoorFinal1 = tmpyF1;
						
						if(CoorInicial1 > CoorFinal1)
						{
							if (diferenciaX1 > 50) 
							{
								if(tmpxF1 > tmpxI1)
								{
									Sector[4] = 1;
									if(Sector[2]==1)
									{
										Debug.Log("Scale total");
										objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
										w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
										h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
									}
								}
								if(tmpxF1 < tmpxI1)
								{
									Sector[3] = 1;
									if(Sector[1]==1)
									{
										Debug.Log("Scale total");
										objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
										w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
										h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
									}
								}
							}
							if(diferenciaX1 < 50){
								Sector[7] = 1;
								if(Sector[5]==1)
								{
									Debug.Log("Scale a lo alto");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								}
							}
							//Debug.Log("Movimiento hacia abajo");
						}
						
						if(CoorInicial1 < CoorFinal1 ){
							
							if (diferenciaX1 > 50) 
							{
								if(tmpxF1 > tmpxI1)
								{
									Sector[1] = 1;
									if(Sector[3]==1)
									{
										Debug.Log("Scale total");
										objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
										w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
										h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
									}
								}
								if(tmpxF1 < tmpxI1)
								{
									Sector[2] = 1;
									if(Sector[4]==1)
									{
										Debug.Log("Scale total");
										objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x + 1f, objeto.rectTransform.sizeDelta.y + 1f);
										w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
										h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
									}
								}
							}
							if(diferenciaX1 < 50)
							{
								Sector[5] = 1;
								if(Sector[7]==1)
								{
									Debug.Log("Scale a lo alto");
									objeto.rectTransform.sizeDelta = new Vector2(objeto.rectTransform.sizeDelta.x, objeto.rectTransform.sizeDelta.y + 1f);
									w = Convert.ToInt32(objeto.rectTransform.sizeDelta.x);
									h = Convert.ToInt32(objeto.rectTransform.sizeDelta.y);
								}
							}
						}
					}
					if(Input.GetTouch (0).phase == TouchPhase.Ended && Input.GetTouch (1).phase == TouchPhase.Ended)
					{
						for(int i = 1; i <= 8; i++)
						{
							Sector[i]=0;
						}
						/*string MiNombre = objeto.mainTexture.name;
						TextureImporter tImporter = AssetImporter.GetAtPath("Assets/Resources/Face2/"+MiNombre+".png") as TextureImporter;
						tImporter.mipmapEnabled = true;
						tImporter.isReadable = true;
						tImporter.maxTextureSize = h;
						AssetDatabase.ImportAsset( "Assets/Resources/Face2/"+MiNombre+".png", ImportAssetOptions.ForceUpdate );
						return h;*/
					}
				}
			}
		}
		return 0;
	}
}